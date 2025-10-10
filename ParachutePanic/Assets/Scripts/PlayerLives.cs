using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLives : MonoBehaviour
{
    // In case i might refactor this class too
    // public int currentLives = ?;
    // public GameObject gameOverPanel;
    // public TMP_Text livesText;
    public ScoreManager scoreManager;
    public LivesManager livesManager;
    
    public int lives = 3;
    public Image[] livesUI;
    public GameObject hitImpactPrefab;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Enemy")
        {
            Destroy(collision.collider.gameObject);
            Instantiate(hitImpactPrefab, transform.position, quaternion.identity);
            
            lives -= 1;
            for (int i = 0; i < livesUI.Length; i++)
            {
                if (i < lives)
                {
                    livesUI[i].enabled = true;
                }
                else
                {
                    livesUI[i].enabled = false;
                }
            }
            if (lives <= 0)
            {
                //Destroy(gameObject);
                livesManager.LoseLife();
            }
        }
    }

    /*public void LoseLife()
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
    }*/
}
