using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private HighscoreHandler highscoreHandler;
    [SerializeField] private InputHandler inputHandler;
    private string playerName; // Convert to setter, maybe ever?

    //[SerializeField] private TMP_InputField nameInput;
    //[SerializeField] private string filename;

    // Try, refactor or make <HighscoreElement> instead.
    private List<InputEntry> entries = new List<InputEntry>();

    [SerializeField] private PlayerLives livesManager;

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

    // TO-DO: Find a way to communicate the nameInput (which is the name the player enters in an InputField)

    // TO-DO: Find a way to communicate the finalScore (whatever the currentScore variable ended at on EndGame()). 
    // Solved? By using a public getter property.
    public void StopGame()
    {
        highscoreHandler.AddHighscoreIfPossible 
            (new HighscoreElement(inputHandler.Name, scoreManager.Score));

        Time.timeScale = 0;
        // Call manager to stop the game
    }
}