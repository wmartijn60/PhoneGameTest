using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManagerPeter : MonoBehaviour
{
    public enum gameState { gameBegin, gameInGame, gameLose, gameWin }

    [Header("Current Game State")]
    public gameState gameStateCurrent = gameState.gameBegin;

    [Header("In Game Canvasses")]
    [SerializeField]
    private GameObject[] gameCanvasses;// This needs to be an static array

    [Header("Main Camera")]
    [SerializeField]
    private Camera mainCamera;


    private GameObject levelEndPoint;

    void Start()
    {
        levelEndPoint = GameObject.Find("LevelEndPoint");
    }

    private void FixedUpdate()
    {
        CheckGameState();
    }


    void CalculateProgress()
    {

    }

    void CheckGameState()
    {
        //Check the current game state and sets the canvas active relative to the enum
        for (int _i = 0; _i < gameCanvasses.Length; _i++)
        {
            if (_i == (int)gameStateCurrent)
                gameCanvasses[_i].SetActive(true);
            else
                gameCanvasses[_i].SetActive(false);
        }
    }

    public void GameStart()
    {
        gameStateCurrent = gameState.gameInGame;
        mainCamera.GetComponent<AddMovement>().gsCanMove = true;
    }
}
