using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] 
    private float moveSpeed = 5;
    private float horizontalInput;
    
    private void Start()
    {
        // To-do: lerp for possible spawn in sequence
        transform.position = new Vector3(0, -3, 0);
    }

    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        
        // To-do: Make movement snappy
        transform.Translate(Vector2.right * horizontalInput * moveSpeed * Time.deltaTime);
    }
}
