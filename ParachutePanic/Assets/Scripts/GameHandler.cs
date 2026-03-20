using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameHandler : MonoBehaviour
{
    public GameObject highscoreMenu;
    
    [SerializeField] private ScoreManager scoreManager;
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

    // TODO: Find a way to communicate the nameInput (which is the name the player enters in an InputField)
    private void EnterName()
    {
        if (inputHandler.Name == "")
        {
            highscoreMenu.SetActive(true);
        }
        
        // if (inputHandler.Name != "")
        // {
        //     inputHandler.Name = playerName;
        //     StopGame();
        // }
    }
    
    public void StopGame()
    {
        highscoreHandler.AddHighscoreIfPossible 
            (new HighscoreElement(inputHandler.Name, scoreManager.Score));
    }
}