using System;
using UnityEngine;

/// <summary>
/// This class visualizes collision points by instantiating prefabs
/// at the point the collision happens.
/// </summary>

public class CollisionVisualizer : MonoBehaviour
{
    public GameObject prefab;
    
    // TO-DO: Maak een tag aan en geef je eerste prefab die tag... colliden met.. prefab.
    // TO-DO: Gebruik het spawn on collision Component ook voor je tweede prefab... to crash Unity?
    
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
