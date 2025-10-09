using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cluster : MonoBehaviour
{
    public float moveSpeed;

    private void Start()
    {
        //moveSpeed = rb.AddForceX(2.0f);
    }

    private void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        //UpdateClusterPos();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Een tag aanmaken en dan checken Als je een GameObject met deze velocity = -velocity
        if (collision.gameObject.CompareTag("Boundary"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
            moveSpeed *= -1;
        }
    }
}
