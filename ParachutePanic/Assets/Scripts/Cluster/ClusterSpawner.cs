using System.Collections;
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Custom spawner Component class:
/// This spawns in (cluster) game objects positioned randomly.
/// </summary>

public class ClusterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject clusterPrefab;
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private GameObject healPrefab;
    
    [SerializeField] private float clusterInterval;
    [SerializeField] private float obstacleInterval;
    [SerializeField] private float healInterval;

    private List<GameObject> spawnedClusters;
    private int amountToSpawn;
    private int horizontalMinX;
    private int horizontalMaxX;
    private int verticalMinY;
    private int verticalMaxY;

    private void Awake()
    {
        horizontalMinX = -8;
        horizontalMaxX = 8;
        verticalMinY = 8;
        verticalMaxY = 80;

        if ( clusterPrefab == null )
            Debug.LogWarning( "Prefab was null" );

        spawnedClusters = new List<GameObject>();

        
        GetComponent<Cluster>();
    }

    private void Start()
    {
        StartCoroutine( SpawnCluster ( clusterInterval, clusterPrefab ));
        StartCoroutine( SpawnCluster ( obstacleInterval, obstaclePrefab ));
        StartCoroutine( SpawnCluster ( healInterval, healPrefab ));
    }

    private IEnumerator SpawnCluster( float interval, GameObject cluster )
    {
        yield return new WaitForSeconds(interval);
        
        var newCluster = Instantiate(cluster, 
            new Vector2(
            Random.Range( horizontalMinX, horizontalMaxX ),
            Random.Range( verticalMinY, verticalMaxY )), // To-do * -5 equation
            Quaternion.identity);

        StartCoroutine( SpawnCluster ( interval, cluster ));
    }
    
}
