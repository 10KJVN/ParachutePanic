using UnityEngine;

/// <summary>
/// Simple free-fly camera for the Built-in Render Pipeline.
/// Attach this to your Camera and play — right mouse to look around, WASD + QE to move.
/// </summary>
[RequireComponent(typeof(Camera))]
public class FreeCamera : MonoBehaviour
{
    [Header("Look Settings")]
    public float lookSpeed = 3f;
    public float lookSmooth = 5f;

    [Header("Move Settings")]
    public float moveSpeed = 10f;
    public float turboMultiplier = 5f;

    private float rotationX;
    private float rotationY;
    private Vector3 currentVelocity;

    void Start()
    {
        // Lock and hide the cursor initially
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Initialize rotation
        Vector3 euler = transform.eulerAngles;
        rotationX = euler.y;
        rotationY = euler.x;
    }

    void Update()
    {
        HandleMouseLook();
        HandleMovement();

        // Escape key toggles cursor lock
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = !Cursor.visible;
            Cursor.lockState = Cursor.visible ? CursorLockMode.None : CursorLockMode.Locked;
        }
    }

    void HandleMouseLook()
    {
        if (Cursor.lockState != CursorLockMode.Locked)
            return;

        float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeed;

        rotationX += mouseX;
        rotationY -= mouseY;
        rotationY = Mathf.Clamp(rotationY, -90f, 90f);

        Quaternion targetRot = Quaternion.Euler(rotationY, rotationX, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, Time.deltaTime * lookSmooth);
    }

    void HandleMovement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        // Q = down, E = up
        float moveY = 0f;
        if (Input.GetKey(KeyCode.E)) moveY += 1f;
        if (Input.GetKey(KeyCode.Q)) moveY -= 1f;

        Vector3 moveDir = (transform.forward * moveZ + transform.right * moveX + transform.up * moveY).normalized;

        float speed = moveSpeed * (Input.GetKey(KeyCode.LeftShift) ? turboMultiplier : 1f);
        Vector3 targetPos = transform.position + moveDir * speed * Time.deltaTime;

        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref currentVelocity, 0f);
    }
}
