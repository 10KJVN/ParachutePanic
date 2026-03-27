using UnityEngine;

/// <summary>
/// This class tracks the player's input required
/// To perform an attack or similar action to that.
/// </summary>

public class PlayerAttack : MonoBehaviour
{
    public GameObject attackPrefab;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(attackPrefab, transform.position, Quaternion.identity);
        }
    }
}
