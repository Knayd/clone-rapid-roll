using UnityEngine;

public class Despawner : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        IDespawnable objectToDespawn = other.gameObject.GetComponent<IDespawnable>();
        if (objectToDespawn != null)
        {
            objectToDespawn.Despawn();
        }
    }
}
