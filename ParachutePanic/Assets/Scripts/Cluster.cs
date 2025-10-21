using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cluster : MonoBehaviour
{
    public Rigidbody2D rb;
    
    [Header("Math variables")] // Default values
    [SerializeField] private float additiveForce = 1f;

    private void Start()
    {
        //throw new NotImplementedException();
    }

    private void Update()
    {
        rb.AddForceX(additiveForce * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        additiveForce = -additiveForce; // Flips move direction
    }
}