using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cluster : MonoBehaviour
{
    public Rigidbody2D rb;
    
    [Header("Math variables")] // Default values
    [SerializeField] private float additiveForce = 1.0f;

    private float rotation = 0.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    private void FixedUpdate()
    {
        rb.AddForceX(additiveForce * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        additiveForce = -additiveForce; // Flips move direction
    }
}