using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gamelevel : MonoBehaviour
{
    public uint worldLevel;

    // Start is called before the first frame update
    void Start()
    {
        int gameLevel = (Convert.ToInt32(worldLevel) * 10) - 9;

        Button[] buttons = GetComponentsInChildren<Button>();
        foreach (Button button in buttons)
        {
            button.GetComponentInChildren<Text>().text = gameLevel.ToString();
            gameLevel++;
        }
    }

    public void runLevel(Text gameLevel)
    {
        GameSceneInfo.level = Convert.ToInt32(gameLevel.text);
        SceneManager.LoadScene("GameInstanceInfo");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
