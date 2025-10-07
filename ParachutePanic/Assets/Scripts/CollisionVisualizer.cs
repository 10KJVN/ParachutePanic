using UnityEngine;

public class CollisionVisualizer : MonoBehaviour
{
    public GameObject prefab;
    private void OnTriggerEnter(Collider other)
    {
        GameObject go = Instantiate(prefab);
        Debug.Log(other.gameObject.name);

        Spawner spawner = other.gameObject.GetComponent<Spawner>();
        if (spawner != null)
        {
            spawner.GetAmountSpawned();
        }

        //spawner.spawnedObjects.contacts[0].point;
    }
}
