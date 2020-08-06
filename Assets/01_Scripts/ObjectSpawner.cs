using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectSpawner : MonoBehaviour
{
    public abstract GameObject GetObjectToSpawn();
    public abstract Vector2 GetPositionToSpawnOn();

    public void Spawn()
    {
        var objectToSpawn = GetObjectToSpawn();
        var positionToSpawnOn = GetPositionToSpawnOn();

        if (objectToSpawn != null && positionToSpawnOn != null)
        {
            objectToSpawn.transform.position = positionToSpawnOn;
            objectToSpawn.SetActive(true);
        }
    }
}
