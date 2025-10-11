using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5;
    private float hInput;
    
    private void Start()
    {
        // To-do: lerp for possible spawn in sequence
        transform.position = new Vector3(0, -3, 0);
    }

    private void Update()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        
        // To-do: Make movement snappy
        transform.Translate(Vector2.right * hInput * moveSpeed * Time.deltaTime);
    }
}
