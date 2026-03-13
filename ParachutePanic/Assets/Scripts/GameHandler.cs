using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour {
    [SerializeField] PointCounter pointCounter;
    [SerializeField] HighscoreHandler highscoreHandler;
    [SerializeField] PointHUD pointHUD;
    [SerializeField] InputHandler inputHandler;
    [SerializeField] string playerName;
    
    public void StartGame () {
        pointCounter.StartGame ();
    }
    public void StopGame () {
        highscoreHandler.AddHighscoreIfPossible (new HighscoreElement (playerName, pointHUD.Points));
        pointCounter.StopGame ();
    }
}

// using System;
// using System.Collections.Generic;
// using UnityEngine;
// using TMPro;
//
// public class GameHandler : MonoBehaviour
// {
//     [SerializeField] private ScoreManager scoreManager;
//     [SerializeField] private HighscoreHandler highscoreHandler;
//     [SerializeField] private InputHandler inputHandler;
//     
//     [SerializeField] private TMP_InputField nameInput;
//     //[SerializeField] private string filename;
//     [SerializeField] private bool hasGameStarted = false;
//     
//     // Try, refactor or make <HighscoreElement> instead.
//     private List<InputEntry> entries = new List<InputEntry>();
//
//     public void StartGame()
//     {
//         if (scoreManager.currentScore != 0)
//         {
//             hasGameStarted = true;
//         }
//     }
//     
//     public void StopGame()
//     {
//         highscoreHandler.AddHighscoreIfPossible
//             ( new HighscoreElement(inputHandler.GetName(), scoreManager.GetScore()) );
//         
//         hasGameStarted = false;
//     }
// }