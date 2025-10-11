using UnityEngine;

public class Move2D : MonoBehaviour
{
    public Rigidbody2D rb;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            rb.AddForceX(-200);
        }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            rb.AddForceX(200);
        }
        
        // This is if you HOLD 'S'
        if (Input.GetKey(KeyCode.Z))
        {
            rb.AddForceX(-1);
        }
        
        if (Input.GetKey(KeyCode.C))
        {
            rb.AddForceX(1);
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForceY(100);
        }
        
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            rb.AddForceY(-100);
        }
    }
}
