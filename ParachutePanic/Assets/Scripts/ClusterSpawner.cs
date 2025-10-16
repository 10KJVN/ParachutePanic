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

    private void Start()
    {
        StartCoroutine(spawnCluster(clusterInterval, clusterPrefab));
        StartCoroutine(spawnCluster(obstacleInterval, obstaclePrefab));

    }

    private IEnumerator spawnCluster(float interval, GameObject cluster)
    {
        yield return new WaitForSeconds(interval);
        GameObject newCluster = Instantiate(cluster,
            new Vector2(Random.Range(-9, 9), Random.Range(5, 50) ), Quaternion.identity);

        StartCoroutine(spawnCluster(interval, cluster));
    }
    
}
