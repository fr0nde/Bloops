using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public enum EventEnum
{
    SLOW,
    KILL
}

public class PlayerCharacter : MonoBehaviour
{
    public float speed;//Floating point variable to store the player's movement speed.

    private Animator anim;

    private float currentSpeed;

    private List<string> events;

    private Rigidbody2D character;//Store a reference to the Rigidbody2D component required to use 2D Physics.

    private Dictionary<EventEnum, bool> coroutineState = new Dictionary<EventEnum, bool>();

    private IEnumerator coroutine;

    private StatsManager parentScript;
    private int test = 0;

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 50, 50), test.ToString());
    }

    // Triger respawn after death animation
    public void EndDeathAnimation()
    {
        // Triger respawn after death animation
        character.position = GameInstanceInfo.positionDepart;
        anim.SetBool("is_dead", false);
    }

    internal void EventCoroutine(float timer, EventEnum typeEvent, Action fctStart, Action fctEnd)
    {
        if (coroutineState.ContainsKey(typeEvent) && coroutineState[typeEvent] == true)
        {
            print("je skipp");
            return;

        }
        coroutineState[typeEvent] = true;
        fctStart();
        coroutine = WaitAndPrint(timer, typeEvent, fctEnd);
        StartCoroutine(coroutine);
    }

    private IEnumerator WaitAndPrint(float waitTime, EventEnum typeEvent, Action callback)
    {
        yield return new WaitForSeconds(waitTime);
        callback();
        coroutineState[typeEvent] = false;
    }

    internal void Start()
    {
        anim = GetComponent<Animator>();
        parentScript = transform.parent.GetComponent<StatsManager>();

        //Get and store a reference to the Rigidbody2D component so that we can access it.
        character = GetComponent<Rigidbody2D>();
        currentSpeed = speed;
    }

    public void LaunchPlayer(Vector3 dragDistance)
    {
        if (parentScript != null) {
            parentScript.OnStartGame();
            parentScript.OnMoveCharacter();
        }

        anim.SetBool("is_launching", true);
        anim.SetFloat("xInput", dragDistance.x);
        anim.SetFloat("yInput", dragDistance.y);

        int rdmSoundLaunch = UnityEngine.Random.Range(1, 4);
        SoundManager.PlaySound("launch_"+ rdmSoundLaunch);
        // Reset the force
        character.velocity = new Vector2(0f, 0f);

        character.AddForce(-dragDistance * speed, ForceMode2D.Impulse);

        GameInstanceInfo.nbBounce++;
    }

    IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
        character.velocity = Vector2.zero;
        anim.SetBool("is_launching", false);

        // rdm sound just for test
        int rdmSound = UnityEngine.Random.Range(1, 4);
        int rdmSoundDeath = UnityEngine.Random.Range(1, 3);
        SoundManager.PlaySound("impact_"+ rdmSound);

        if (collision.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene("EndLevel");
            yield return null;
        }
        if (collision.gameObject.tag == "Bloc_Kill")
        {
            anim.SetBool("is_dead", true);
            SoundManager.PlaySound("death_" + rdmSoundDeath);

            print($"Le personnage est mort il à touché le bloc qui tue");
            GameInstanceInfo.nbTry++;
            yield return null;
        }
        if (collision.gameObject.tag == "Bloc_Slow")
        {
            print($"Le personnage est ralentit");
            EventCoroutine(5F, EventEnum.SLOW, () => SetPlayerSpeed(0.2F, EventEnum.SLOW), () => SetPlayerSpeed(1F, EventEnum.SLOW));
            yield return null;
        }

        Vector3 coolideWorldPos = collision.contacts[0].point;

        // Calculate Angle Between the collision point and the player
        Vector3 dir = coolideWorldPos - transform.position;
        // We then get the opposite (-Vector3) and normalize it
        dir = -dir.normalized;
        // And finally we add force in the direction of dir and multiply it by force. 
        // This will push back the player
        character.AddForce(dir * 40);
        yield return new WaitForSeconds(0.1f);
        character.velocity = Vector2.zero;
        yield return null;
    }

    void SetPlayerSpeed(float speedRate, EventEnum typeEvent)
    {
        float newSpeed = speed * speedRate;
        print($"La vitesse du joueur à été modifier, current: {currentSpeed} => new: {newSpeed}");
        currentSpeed = newSpeed;
        coroutineState[typeEvent] = false;
    }
}
