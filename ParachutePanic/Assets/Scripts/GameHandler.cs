using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private HighscoreHandler highscoreHandler;
    [SerializeField] private InputHandler inputHandler;
    [SerializeField] private PlayerLives livesManager;
    private string playerName; // Convert to setter, maybe ever?
    
    private void OnEnable()
    {
        livesManager.OnDeath += StopGame;
    }

    private void OnDisable()
    {
        livesManager.OnDeath -= StopGame;
    }

    public void StartGame()
    {
        // Call manager to start the game
    }

    // TODO: Find a way to communicate the nameInput (which is the name the player enters in an InputField)
    
    public void StopGame()
    {
        highscoreHandler.AddHighscoreIfPossible 
            (new HighscoreElement(inputHandler.Name, scoreManager.Score));

        Time.timeScale = 0;
        // Call manager to stop the game
    }
}