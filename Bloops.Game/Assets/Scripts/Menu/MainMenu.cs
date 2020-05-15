using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Slider slider = null;
    void Start()
    {
    }

    void Update()
    {
        if (slider)
        {
            slider.value = AudioListener.volume;
        }

    }

    public void PlayGame()
    {
        SceneManager.LoadScene("AventureMenu");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void AdjustVolume()
    {
        AudioListener.volume = slider.value;
    }

    public void ResetProfile()
    {
        Player p = new Player();
        SaveSystem.savePlayer(p);
    }
}
