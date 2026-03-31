using UnityEngine;

/// <summary>
/// Hardcoded solution to score +2 when missing an Obstacle
/// See Cluster.cs ln 69 - ln 73, If curious 'bout reason.
/// </summary>
 
public class BottomBound : MonoBehaviour
{
    [SerializeField] private ScoreHandler scoreSystem;
    [SerializeField] private int missEnemyPoints;

    private void Start()
    {
        scoreSystem = scoreSystem.GetComponent<ScoreHandler>();
        missEnemyPoints = 3;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Gain 3 points, to fake the +2 point gain.
        if (other.collider.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.collider.gameObject);
            scoreSystem.IncrementScore(missEnemyPoints);
        }
    }
}
