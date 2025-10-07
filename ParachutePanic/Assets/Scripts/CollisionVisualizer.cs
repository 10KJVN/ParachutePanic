using UnityEngine;

public class CollisionVisualizer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);

        Spawner spawner = other.gameObject.GetComponent<Spawner>();
        if (spawner != null)
        {
            spawner.GetAmountSpawned();
        }

        //spawner.spawnedObjects.contacts[0].point;
    }
}
