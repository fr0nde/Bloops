using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip playerLaunchSound1, playerLaunchSound2, playerLaunchSound3, playerHitSound1, playerHitSound2, playerHitSound3, playerDeathSound1, playerDeathSound2;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        playerLaunchSound1 = Resources.Load<AudioClip>("Sounds/launch_1");
        playerLaunchSound2 = Resources.Load<AudioClip>("Sounds/launch_2");
        playerLaunchSound3 = Resources.Load<AudioClip>("Sounds/launch_3");
        playerHitSound1 = Resources.Load<AudioClip>("Sounds/impact_1");
        playerHitSound2 = Resources.Load<AudioClip>("Sounds/impact_2");
        playerHitSound3 = Resources.Load<AudioClip>("Sounds/impact_3");
        playerDeathSound1 = Resources.Load<AudioClip>("Sounds/death_1");
        playerDeathSound2 = Resources.Load<AudioClip>("Sounds/death_2");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string sound)
    {
        audioSrc.Stop();

        switch (sound)
        {
            case "launch_1":
                audioSrc.PlayOneShot(playerLaunchSound1);
                break;
            case "launch_2":
                audioSrc.PlayOneShot(playerLaunchSound2);
                break;
            case "launch_3":
                audioSrc.PlayOneShot(playerLaunchSound3);
                break;
            case "impact_1":
                audioSrc.PlayOneShot(playerHitSound1);
                break;
            case "impact_2":
                audioSrc.PlayOneShot(playerHitSound2);
                break;
            case "impact_3":
                audioSrc.PlayOneShot(playerHitSound3);
                break;
            case "death_1":
                audioSrc.PlayOneShot(playerDeathSound1);
                break;
            case "death_2":
                audioSrc.PlayOneShot(playerDeathSound2);
                break;

        }
    }
}
