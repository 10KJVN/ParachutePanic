using System;
using Unity.Mathematics;
using UnityEngine;
using TMPro;

public class PlayerLives : MonoBehaviour
{
    public GameObject hitImpactPrefab;
    public GameObject gameOverMenu;
    public ScoreManager scoreManager;
    
    [Header("Health Configuration")]
    [SerializeField] private int lives;
    [SerializeField] private TMP_Text[] livesUI;
    
    private void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Lose a life if an obstacle hits player
        if (other.collider.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.collider.gameObject);
            scoreManager.ChangeScore(-2);
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
                Destroy(gameObject);
                LoseLife();
            }
        }
        
        // The other collider has to COLLIDE with player, not just a trigger
        if (other.collider.gameObject.CompareTag("Parachute"))
        {
            Destroy(other.collider.gameObject);
            scoreManager.ChangeScore(3);
        }
        
        if (other.collider.gameObject.CompareTag("PowerUp"))
        {
            Destroy(other.collider.gameObject);
            Instantiate(hitImpactPrefab, transform.position, quaternion.identity);
            scoreManager.ChangeScore(2);
            lives += 1;
        }
    }

    private void LoseLife()
    {
        //currentLives -= 1;
        //livesUI.text = currentLives.ToString();
        if (lives <= 0)
        {
            Time.timeScale = 0;
            gameOverMenu.SetActive(true);
            
            // Call the HighScoreUpdate
            scoreManager.HighScoreUpdate();
        }
    }
}
