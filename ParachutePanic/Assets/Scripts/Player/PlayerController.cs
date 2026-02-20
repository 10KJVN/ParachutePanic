using UnityEngine;

/// <summary>
/// This class handles the player's input.
/// It simplys checks for any 'Horizontal' input
/// and moves the player in that direction.
/// </summary>

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5;
    private float horizontalInput;
    
    private void Start()
    {
        transform.position = new Vector3(0, -3, 0);
    }

    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        
        transform.Translate(Vector2.right * horizontalInput * moveSpeed * Time.deltaTime);
    }
}
