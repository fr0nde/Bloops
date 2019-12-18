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

public class PlayerCharacter : GameInstance
{
    public float speed;//Floating point variable to store the player's movement speed.

    private float currentSpeed;

    private List<string> events;

    private Rigidbody2D character;//Store a reference to the Rigidbody2D component required to use 2D Physics.

    private Dictionary<EventEnum, bool> coroutineState;

    private IEnumerator coroutine;

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
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            callback();
            coroutineState[typeEvent] = false;
        }
    }

    internal void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        character = GetComponent<Rigidbody2D>();
    }

    public void LaunchPlayer(Vector3 dragDistance)
    {
        // Reset the force
        character.velocity = new Vector2(0f, 0f);

        character.AddForce(-dragDistance * speed, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        character.velocity = Vector2.zero;

        if (collision.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene("InstanceGame");
        }
        if (collision.gameObject.tag == "BlocKill")
        {
            print($"Le personnage est mort il à touché le bloc qui tue");
        }
        if (collision.gameObject.tag == "Bloc_Slow")
        {
            print($"Le personnage est ralentit");
            EventCoroutine(5F, EventEnum.SLOW, () => setPlayerSpeed(0.2F), () => setPlayerSpeed(1F));
        }
    }

    void setPlayerSpeed(float speedRate)
    {
        float newSpeed = speed * speedRate;
        print($"La vitesse du joueur à été modifier, {currentSpeed} => {newSpeed}");
        currentSpeed = newSpeed;
    }
}
