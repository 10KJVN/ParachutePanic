using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cluster : MonoBehaviour
{
    public ScoreManager scoreManager;
    
    public float HmoveSpeed;
    public float VmoveSpeed;
    
    // Custom init function
    // Begin params meegeven

    // The awake serves as a Constructor
    private void Awake()
    {   
        // This function gives random starting parametrs
        // To each cluster initiated to avoid them from being uniform.
        //InitiateCluster();
    }

    private void InitiateCluster(float height)
    {
        var posX = Random.Range(-9, 9);
        var posY = height * -50;
        throw new NotImplementedException();
    }


    private void Start()
    {
        //moveSpeed = rb.AddForceX(2.0f);
    }

    private void Update()
    {
        transform.Translate(Vector2.right * HmoveSpeed * Time.deltaTime);
        transform.Translate(Vector2.down * VmoveSpeed * Time.deltaTime);
        //UpdateClusterPos();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Een tag aanmaken en dan checken Als je een GameObject met deze velocity = -velocity
        if (collision.gameObject.CompareTag("Boundary"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
            HmoveSpeed *= -1;
        }
        
        if (collision.gameObject.CompareTag("BoundsOut"))
        {
            // Destroys the attack if it goes out of bounds.
            Destroy(gameObject);
            scoreManager.ChangeScore(-2);
        }
    }
}
