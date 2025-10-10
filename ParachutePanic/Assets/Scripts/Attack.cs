using UnityEngine;

public class Attack : MonoBehaviour
{
    public float attackSpeed;
    public GameObject hitImpactPrefab;

    [SerializeField] private PointManager pointManager;
    void Start()
    {
        //pointManager = GetComponent<PointManager>();
        pointManager = GameObject.Find("PointManager").GetComponent<PointManager>();
    }

    void Update()
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
            pointManager.UpdateScore(50);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Boundary"))
        {
            // Destroys the attack if it goes out of bounds.
            Destroy(gameObject);
        }
    }
}
