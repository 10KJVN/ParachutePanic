using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public int currentScore;

    public TMP_Text finalScoreText;
    public TMP_Text highScoreText;
    
    public void ChangeScore(int points)
    {
        currentScore += points;
        scoreText.text = "Score: " + currentScore.ToString();
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
        
        // To-do: Getter & Setter for prettier display in UI.
        //var SavedHighScore;
        
        // Update our TMP reference
        finalScoreText.text = "FINAL: " + currentScore.ToString();
        highScoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("SavedHighScore").ToString();
    }
}
