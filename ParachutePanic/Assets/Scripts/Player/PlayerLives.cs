using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

/// <summary>
/// Kind of a PlayerManager class:
/// Manages life- and score gained on colliding with player
/// </summary>

public class PlayerLives : MonoBehaviour
{
    public GameObject hitImpactPrefab;
    public GameObject healImpactPrefab;
    public GameObject gameOverMenu;
    public ScoreManager scoreManager;

    public Action OnDeath; // Invoke when life <= 0
    
    [Header( "Health Configuration" )]
    [SerializeField] private int lives;
    [SerializeField] private TMP_Text[] livesUI;
    
    private void Start()
    {
        scoreManager = GameObject.Find( "ScoreManager" ).GetComponent<ScoreManager>();
    }

    private void OnCollisionEnter2D( Collision2D other )
    {
        if ( other.collider.gameObject.CompareTag( "Enemy" ) )
        {
            Destroy( other.collider.gameObject );
            scoreManager.ChangeScore( -5 );
            Instantiate( hitImpactPrefab, transform.position, quaternion.identity );
            
            lives -= 1;
            for ( int i = 0; i < livesUI.Length; i++ )
            {
                if ( i < lives )
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
                Destroy( gameObject );
                LoseLife();
            }
        }
        
        if ( other.collider.gameObject.CompareTag( "Parachute" ) )
        {
            Destroy( other.collider.gameObject );
            scoreManager.ChangeScore( +7 );
        }
        
        if ( other.collider.gameObject.CompareTag( "PowerUp" ) )
        {
            Destroy( other.collider.gameObject );
            Instantiate( healImpactPrefab, transform.position, quaternion.identity );
            scoreManager.ChangeScore( +3 );

            if (lives < 5 ) // Capped to increase difficulty.
            {
                lives += 1;
            }

        }
    }

    private void LoseLife()
    {
        if (lives <= 0)
        {
            Time.timeScale = 0;
            gameOverMenu.SetActive( true );

            OnDeath.Invoke();

            // Old method, updates the PlayerPrefs highscore.
            scoreManager.HighScoreUpdate();
        }
    }
}
