using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip playerLaunchSound, playerHitSound1, playerHitSound2, playerHitSound3;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        playerLaunchSound = Resources.Load<AudioClip>("Sounds/launch_1");
        playerHitSound1 = Resources.Load<AudioClip>("Sounds/impact_1");
        playerHitSound2 = Resources.Load<AudioClip>("Sounds/impact_2");
        playerHitSound3 = Resources.Load<AudioClip>("Sounds/impact_3");

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
                audioSrc.PlayOneShot(playerLaunchSound);
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
        }
    }
}
