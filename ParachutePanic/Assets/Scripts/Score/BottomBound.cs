using UnityEngine;

/// <summary>
/// Hardcoded solution to score +2 when missing an Obstacle
/// </summary>
 
public class BottomBound : MonoBehaviour
{
    private ScoreManager scoreManager;
    private ScoreHandler scoreSystem;

    private void Start()
    {
        //scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        scoreSystem = GameObject.Find("Managers").GetComponent<ScoreHandler>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Gain 3 points, to fake the +2 point gain.
        if (other.collider.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.collider.gameObject);
            //scoreManager.ChangeScore( +3 );
            scoreSystem.IncrementScore( 3 );
        }
    }
}
