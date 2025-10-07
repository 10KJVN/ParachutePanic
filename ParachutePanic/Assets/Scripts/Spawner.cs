using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Custom spawner Component class:
/// This spawns in game objects positioned randomly.
/// </summary>
public class Spawner : MonoBehaviour
{
    // 2. Prefab for spawning
    public GameObject prefab;

    private List<GameObject> spawnedObjects;

    private void Start()
    {
        if (prefab == null)
            Debug.LogWarning("Prefab was null");

        spawnedObjects = new List<GameObject>();
    }

    private void Update()
    {
        // Returns true during the frame the user pressed the given mouse button.
        if (Input.GetMouseButtonDown(0))
        {
            Spawn();
        }
        
        // Checks if right-click is pressed.
        else if (Input.GetMouseButtonDown(1))
        {
            Despawn();
        }
        
        // middle mouse button being held down.
        if (Input.GetMouseButton(2))
        {
            Spawn();
        }
    }
    
    // 4. Random start position functionality
    private void Spawn()
    {
        GameObject go = Instantiate(prefab);

        float x = Random.Range(-10, 10);
        float y = Random.Range(-10, 10);
        float z = Random.Range(-10, 10);

        go.transform.localPosition = new Vector3(x, y, z);

        Rigidbody rb = go.AddComponent<Rigidbody>();
        rb.useGravity = false;

        spawnedObjects.Add(go);
    }

    private void Despawn()
    {
        if (spawnedObjects.Count <= 0)
            return;

        int i = Random.Range(0, spawnedObjects.Count);

        Destroy(spawnedObjects[i]);
        spawnedObjects.RemoveAt(i);
    }

    public int GetAmountSpawned()
    {
        //Debug.Log(spawnedObjects.Count);
        return spawnedObjects.Count;
    }
}
