using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectSpawnerOnTopOfPlatform : MonoBehaviour
{
    public abstract GameObject GetObjectToSpawn();
    public abstract float GetTimeInSecondsBetweenSpawns();
    public abstract SpawnArea GetObjectSpawnArea();
    public abstract Vector2 ObjectToSpawnHalfHeight();

    public IEnumerator SpawnObject()
    {
        while (true)
        {
            var platformOnWhichToSpawn = GetPlatformOnWichToSpawn();
            if (platformOnWhichToSpawn != null)
            {
                if (!GetObjectToSpawn().activeInHierarchy)
                {
                    GetObjectToSpawn().transform.position = GetTopPositionOfCollider(platformOnWhichToSpawn) + ObjectToSpawnHalfHeight();
                    GetObjectToSpawn().SetActive(true);
                    yield break;
                }
            }
            yield return new WaitForSeconds(GetTimeInSecondsBetweenSpawns());
        }
    }

    private Collider2D GetPlatformOnWichToSpawn()
    {
        return GetObjectSpawnArea()
                .GetCollidersInsideArea()
                .Find(colliderInArea => colliderInArea.gameObject.CompareTag(Constants.TagPlatform));
    }

    private Vector2 GetTopPositionOfCollider(Collider2D collider)
    {
        var top = collider.bounds.max.y;
        var center = collider.bounds.center.x;
        return new Vector2(center, top);
    }
}
