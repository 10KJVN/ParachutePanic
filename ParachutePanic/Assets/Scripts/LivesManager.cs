using UnityEngine;
using TMPro;

public class LivesManager : MonoBehaviour
{
    
    public int currentLives = 3;
    public GameObject gameOverPanel;
    public TMP_Text livesText;
    
    public ScoreManager scoreManager;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
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
