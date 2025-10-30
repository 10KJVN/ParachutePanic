using UnityEngine;
/// <summary>
///
/// </summary>
public class BottomBound : MonoBehaviour
{
    private ScoreManager scoreManager;
    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Gain 3 points, to fake the +2 point gain.
        if (other.collider.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.collider.gameObject);
            scoreManager.ChangeScore(3);
            
        }
    }
}
