using System;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int currentScore;
    public TMP_Text scoreText;
    public TMP_Text highScoreText;
    public TMP_Text finalScoreText;
    public TMP_Text finalHighScoreText;
    
    public void Awake()
    {
        DisplayHighScore();
    }

    public void ChangeScore(int points)
    {
        currentScore += points;
        scoreText.text = "Score: " + currentScore.ToString();
    }

    private void DisplayHighScore()
    {
        highScoreText.text = PlayerPrefs.GetInt("SavedHighScore").ToString();
    }

    public void HighScoreUpdate()
    {
        // Is there already a highscore?
        if (PlayerPrefs.HasKey("SavedHighScore"))
        {
            // is the new score higher than the saved one?
            if (currentScore > PlayerPrefs.GetInt("SavedHighScore"))
            {
                // Set a new high score
                PlayerPrefs.SetInt("SavedHighScore", currentScore);
            }
        }
        else
        {
            // If there is no highscore, set it
            PlayerPrefs.SetInt("SavedHighScore", currentScore);
        }
        
        // Update our TMP reference
        finalScoreText.text = "FINAL: " + currentScore.ToString();
        finalHighScoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("SavedHighScore").ToString();
    }
}
