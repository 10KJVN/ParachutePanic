using UnityEngine;

/// <summary>
/// This class ensures the player can't go out of screen bounds.
/// It measures the objectWidth of a SpriteRenderer and calculates
/// The screen bounds based off the camera's Width, Height.
/// </summary>

public class PlayerBounds : MonoBehaviour
{
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2f;
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2f;
    }

    private void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 - objectWidth, screenBounds.x + objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 - objectWidth, screenBounds.y + objectWidth);

        transform.position = viewPos;
    }
}
