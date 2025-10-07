using System;
using UnityEngine;

public class CollisionVisualizer : MonoBehaviour
{
    public GameObject prefab;

    private void OnCollisionEnter(Collision other)
    {
        GameObject go = prefab;
        Debug.Log(other.gameObject.name);
        
        // Get the first contact point of the collision
        ContactPoint contact = other.contacts[0];
        
        // Calculate rotation to align with the contact surface normal
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        
        // Get the position of the contact point
        Vector3 pos = contact.point;

        // Instantiate the explosion prefab at the contact point
        Instantiate(go, pos, rot);
    }
}
