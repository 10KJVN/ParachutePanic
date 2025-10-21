using System;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;

/// <summary>
/// Custom spawner Component class:
/// This spawns in game objects positioned randomly.
/// </summary>
public class ClusterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject clusterPrefab;
    [SerializeField] private GameObject obstaclePrefab;
    
    [SerializeField] private float clusterInterval;
    [SerializeField] private float obstacleInterval;
    
    //private Cluster cluster;
    private List<GameObject> spawnedClusters;
    private int amountToSpawn;
    
    private void Awake()
    {
        if (clusterPrefab == null)
            Debug.LogWarning("Prefab was null");

        spawnedClusters = new List<GameObject>();

        // 'MonoBehaviour' instances must be instantiated with 'GameObject.AddComponent<T>()' instead of 'new
        // cluster = gameObject.AddComponent<Cluster>();
        
        for (int t = 0; t <= 10; t = t + 1)
        {
            //spawnedClusters.Add(new cluster(clusterPrefab));
        }
        GetComponent<Cluster>();
    }

    private void Start()
    {
        StartCoroutine(SpawnCluster(clusterInterval, clusterPrefab));
        StartCoroutine(SpawnCluster(obstacleInterval, obstaclePrefab));

    }

    // Recursive function ??
    private IEnumerator SpawnCluster(float interval, GameObject cluster)
    {
        yield return new WaitForSeconds(interval);
        
        // Merely the position cluster spawns at
        var newCluster = Instantiate(cluster, 
            new Vector2(
            Random.Range(-8, 8),
            Random.Range(5, 50)), // To-do * -5 equation
            Quaternion.identity);

        StartCoroutine(SpawnCluster(interval, cluster));
    }
    
}
