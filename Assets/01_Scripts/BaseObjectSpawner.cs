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
                    GetObjectToSpawn().transform.position = GetTopPositionOfGameObject(objectOnWhichToSpawn);
                    GetObjectToSpawn().SetActive(true);
                    yield break;
                }
            }
            yield return new WaitForSeconds(GetTimeBetweenSpawns());
        }
    }

    private Vector2 GetTopPositionOfGameObject(GameObject gameObject)
    {
        var centerToTopScale = gameObject.transform.localScale.y / 2;
        var top = gameObject.transform.position.y * centerToTopScale;
        return new Vector2(gameObject.transform.position.x, top);
    }

    private GameObject GetObjectOnWichToSpawn()
    {
        return GetObjectSpawnArea()
                .GetObjectsInsideArea()
                .Find(objectInArea => objectInArea.CompareTag(GetObjectTagOnWhichToSpawn()));
    }
}
