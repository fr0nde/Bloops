using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StatsManager : MonoBehaviour
{

    private int moveCount = 0;
    private float gameTime = 0.0f;
    private bool gameIsRunning = false;
    public Text tmpTimer;
    public Text tmpMove;
    void Start()
    {
        
    }

    void Update()
    {
        if (gameIsRunning) {
            gameTime += Time.deltaTime;
            tmpTimer.text = gameTime.ToString();
        }
    }

    public void OnMoveCharacter()
    {
        moveCount += 1;
        tmpMove.text = moveCount.ToString();
        Debug.Log("MOVE DETECTER");
    }

    public void OnStartGame()
    {
        gameIsRunning = true;
        Debug.Log("GAME START");
    }

    public void OnStopGame()
    {
        gameIsRunning = false;
        Debug.Log("GAME STOP");
    }
}
