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
    public Action OnDeath;
    public GameObject hitImpactPrefab;
    public GameObject healImpactPrefab;
    public GameObject gameOverMenu;
    
    [SerializeField] private ScoreHandler scoreSystem;
    
    [Header( "Health Configuration" )]
    [SerializeField] private int lives = 3;
    [SerializeField] private int maxLives = 5;
    [SerializeField] private TMP_Text[] livesUI;
    
    private void Start()
    {
        scoreSystem = scoreSystem.GetComponent<ScoreHandler>();
    }

    private void OnCollisionEnter2D( Collision2D other )
    {
        if ( other.collider.gameObject.CompareTag( "Enemy" ) )
        {
            Destroy( other.collider.gameObject );
            scoreSystem.DecrementScore(5);
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
            scoreSystem.IncrementScore(7);
        }
        
        if ( other.collider.gameObject.CompareTag( "PowerUp" ) )
        {
            Destroy( other.collider.gameObject );
            Instantiate( healImpactPrefab, transform.position, quaternion.identity );
            scoreSystem.IncrementScore(3);
            
            if ( lives < maxLives )
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
        }
    }
}
