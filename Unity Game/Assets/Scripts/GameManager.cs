using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        menu, inGame, gameOver
    }

    public static GameManager instance;
    public GameState currentGameState = GameState.menu;

    private void Awake()
    {
        instance = this;
    }

    public void StartGame()
    {
        SetGameState(GameState.inGame);
    }

    public void GameOver()
    {
        
    }

    public void BackTomenu()
    {

    }

    void Start()
    {
        currentGameState = GameState.menu;
    }

    void SetGameState (GameState newGameState)
    {
        if (newGameState == GameState.menu)
        {

        }
        
        else if (newGameState == GameState.inGame)
        {

        }

        else if (newGameState == GameState.gameOver)
        {

        }

        currentGameState = newGameState;
    }

    void Update()
    {
        if (Input.GetButtonDown("s"))
        {
            StartGame();
        }
    }
}
