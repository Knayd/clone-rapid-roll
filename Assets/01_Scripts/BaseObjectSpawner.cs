using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseObjectSpawner : MonoBehaviour
{
    public abstract GameObject GetObjectToSpawn();
    public abstract float GetTimeBetweenSpawns();
    public abstract SpawnArea GetObjectSpawnArea();
    public abstract string GetObjectTagOnWhichToSpawn();

    public IEnumerator SpawnObject()
    {
        while (true)
        {
            var objectOnWhichToSpawn = GetObjectOnWichToSpawn();
            if (objectOnWhichToSpawn != null)
            {
                if (!GetObjectToSpawn().activeInHierarchy)
                {
                    GetObjectToSpawn().transform.position = objectOnWhichToSpawn.transform.position;
                    GetObjectToSpawn().SetActive(true);
                    yield break;
                }
            }
            yield return new WaitForSeconds(GetTimeBetweenSpawns());
        }
    }

    private GameObject GetObjectOnWichToSpawn()
    {
        return GetObjectSpawnArea()
                .GetObjectsInsideArea()
                .Find(objectInArea => objectInArea.CompareTag(GetObjectTagOnWhichToSpawn()));
    }
}
