using UnityEngine;

public class Rotate : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Start");
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.Euler(0, 90, 0);
        transform.localScale = Vector3.one;
    }
    
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, -100 * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, 100 * Time.deltaTime, 0);
        }
    }
}