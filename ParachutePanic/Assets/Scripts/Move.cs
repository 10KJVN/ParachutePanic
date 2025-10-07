using UnityEngine;

public class Move : MonoBehaviour
{
    public Rigidbody rb;
    
    void Start()
    {
        Debug.Log("Init Move.cs");
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(0, 0, 200);
            Debug.Log("To the front");
        }
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.AddForce(200, 0, 0);
            Debug.Log("To the left");
        }
        
        // This if you press 'S' repeatedly
        if (Input.GetKeyDown(KeyCode.S))
        {
            rb.AddForce(0, 0, -200);
            Debug.Log("To the back");
        }

        // This is if you HOLD 'S'
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(0, 0, -1);
        }
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            rb.AddForce(-200, 0, 0);
            Debug.Log("To the right");
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(0, 250, 0);
            Debug.Log("Up!");
        }
    }
}
