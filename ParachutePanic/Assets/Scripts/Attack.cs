using UnityEngine;

public class Attack : MonoBehaviour
{
    public float attackSpeed;
    public GameObject hitImpactPrefab;
    void Start()
    {
        
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
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Boundary"))
        {
            // Destroys the attack if it goes out of bounds.
            Destroy(gameObject);
        }
    }
}
