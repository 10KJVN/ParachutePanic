using UnityEngine;

/// <summary>
/// This class is the Attack itself.
/// Whatever the attack should be and do is defined here.
/// </summary>

public class Attack : MonoBehaviour
{
    public float attackSpeed;
    public GameObject hitImpactPrefab;

    [SerializeField] private ScoreManager scoreManager;

    private void Start()
    {
        //ScoreManager = GetComponent<PointManager>();
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    private void Update()
    {
        transform.Translate(Vector2.up * attackSpeed * Time.deltaTime);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(hitImpactPrefab, transform.position, Quaternion.identity);
            
            // Destroys the GameObject the attack collides with.
            Destroy(collision.gameObject);
            scoreManager.ChangeScore(10);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Boundary"))
        {
            // Destroys the attack if it goes out of bounds.
            Destroy(gameObject);
        }
    }
}
