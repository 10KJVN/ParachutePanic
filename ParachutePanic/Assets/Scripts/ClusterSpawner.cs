using System;
using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;

/// <summary>
/// Custom spawner Component class:
/// This spawns in game objects positioned randomly.
/// </summary>
public class ClusterSpawner : MonoBehaviour
{
    
    public GameObject clusterPrefab;
    
    private List<GameObject> spawnedClusters;
    private int amountToSpawn;

    private Cluster cluster;

    private void Awake()
    {
        if (clusterPrefab == null)
            Debug.LogWarning("Prefab was null");

        spawnedClusters = new List<GameObject>();

        // 'MonoBehaviour' instances must be instantiated with 'GameObject.AddComponent<T>()' instead of 'new
        cluster = gameObject.AddComponent<Cluster>();
        
        for (int t = 0; t <= 10; t = t + 1)
        {
            //spawnedClusters.Add(new cluster(clusterPrefab));
        }
        GetComponent<Cluster>();
    }
    
}
