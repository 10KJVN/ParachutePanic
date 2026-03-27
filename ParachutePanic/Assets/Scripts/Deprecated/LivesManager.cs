using UnityEngine;
using TMPro;

/// <summary>
/// Old method I tried to manage player lifes,
/// but I found it a hassle to use so i -> PlayerLives.cs
/// </summary>

public class LivesManager : MonoBehaviour
{
    public int currentLives = 3;
    public GameObject gameOverPanel;
    public TMP_Text livesText;
    public ScoreManager scoreManager;
    
    public void LoseLife()
    {
        currentLives -= 1;
        livesText.text = currentLives.ToString();
        if (currentLives <= 0)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);

            // Call the HighScoreUpdate
            scoreManager.HighScoreUpdate();
        }
    }
}
