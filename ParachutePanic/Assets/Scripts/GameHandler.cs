using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameHandler : MonoBehaviour
{
    public GameObject highscoreMenu;
    
    // [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private ScoreHandler scoreSystem;
    [SerializeField] private HighscoreHandler highscoreHandler;
    [SerializeField] private InputHandler inputHandler;
    [SerializeField] private PlayerLives livesManager;
    private string playerName; // Convert to setter, maybe ever?
    
    private void OnEnable()
    {
        livesManager.OnDeath += EnterName;
    }

    private void OnDisable()
    {
        livesManager.OnDeath -= EnterName;
    }

    public void StartGame()
    {
        // Call manager to start the game
    }

    // TODO: Find a way to communicate the nameInput
    private void EnterName()
    {
        if (inputHandler.Name == "")
        {
            highscoreMenu.SetActive(true);
        }

        // A UnityEvent on the enter button of the EnterHighscore_Widget.
        // That's how it communicates to call -> StopGame() function.
    }
    
    public void StopGame()
    {
        highscoreHandler.AddHighscoreIfPossible 
            (new HighscoreElement(inputHandler.Name, scoreSystem.Score));
    }
}