using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cluster : MonoBehaviour
{
    public ScoreManager scoreManager;
    
    public float HmoveSpeed;
    public float VmoveSpeed;

    private int posX;
    private int posY;
    
    private int speedX;
    private int speedY;
    
    // Custom init function
    // Begin params meegeven

    // The awake serves as a Constructor
    private void Awake()
    {   
        // This function gives random starting parametrs
        // To each cluster initiated to avoid them from being uniform.
        //InitiateCluster();
    }

    private void InitiateCluster(int height)
    {
        posX = Random.Range(-9, 9);
        posY = height * -5;
        
        speedX = Random.Range(7, 16);
        speedY = Random.Range(6, 7);
        
        Debug.Log("Position + " + posX + "Height: " + posY);
        Debug.Log("Speed: " + speedX + speedY);
    }


    private void Start()
    {
        HmoveSpeed = posX + speedX;
        VmoveSpeed = posY + speedY;
        
        for (int t = 0; t <= 10; t += 1)
        {
            InitiateCluster(t);
        }
    }

    private void Update()
    {
        //UpdateClusterPosition();
        transform.Translate(Vector2.right * HmoveSpeed * Time.deltaTime);
        transform.Translate(Vector2.down * VmoveSpeed * Time.deltaTime);
        UpdateClusterPosition();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // This is basically the 'CalculateVelocity' function.
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

    int CalculatePosition(int currentPos, int velocity)
    {
        return currentPos + velocity;
    }

    int calculateVelocity(int pos, int velocity, int min, int max)
    {
        if (pos <= min || pos >= max)
        {
            velocity *= -1;
        }

        return velocity;
    }

    private void CheckVisibility()
    {
        if (posY > 8)
        {
            Debug.Log("Cluster above FOV");
        }

        if (posY < -5)
        {
            Debug.Log("Cluster missed");
        }
    }

    private void CustomMovement()
    {
        /*var scale = 50;
        transform.Translate(posX, posY, scale);*/
        
        
    }

    private void UpdateClusterPosition()
    {
        posX = CalculatePosition(posX, speedX);
        speedX = calculateVelocity(posX, speedX, 0, 10);
        
        posY = CalculatePosition(posY, speedY);

        HmoveSpeed = posX * Time.deltaTime;
        VmoveSpeed = posY * Time.deltaTime;

        //CheckVisibility();
    }
}
