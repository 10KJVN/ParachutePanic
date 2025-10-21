using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cluster : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    
    [Header("Math variables")] // Default values
    [SerializeField] private float additiveForce = 1.0f;
    [SerializeField] private float downForce = 1.0f;
   
    private float rotation = 0.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    
    private void FixedUpdate()
    {
        rb.AddForceX(additiveForce * Time.deltaTime);
        rb.AddForceY(-downForce * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        additiveForce = -additiveForce; // Flips move direction
        //rb.rotation = -180;
        sr.flipX = true;
    }
}