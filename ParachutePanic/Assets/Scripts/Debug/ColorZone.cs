using UnityEngine;

public class ColorZone : MonoBehaviour
{
    [SerializeField] private Color color;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);

        ColorChanger colorChanger = other.gameObject.GetComponent<ColorChanger>();
        if (colorChanger != null)
        {
            colorChanger.ChangeColor(color);
        }
    }
}
