using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : ObjectSpawner
{
    [SerializeField] SpawnArea platformSpawnArea;
    private float minSpawnTime = 2f;
    private float maxSpawnTime = 4f;

    void Start()
    {
        StartCoroutine(SpawnPlatform());
    }

    private IEnumerator SpawnPlatform()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
        }
    }

    public override GameObject GetObjectToSpawn()
    {
        string platformTag;

        // 70% chance of getting a normal platform
        platformTag = (Random.value <= 0.7) ? Constants.TagPlatform : Constants.TagSpike;

        return ObjectPooler.SharedInstance.GetPooledObject(platformTag);
    }

    public override Vector2 GetPositionToSpawnOn()
    {
        var minAreaBounds = platformSpawnArea.GetAreaBounds().min;
        var maxAreaBounds = platformSpawnArea.GetAreaBounds().max;
        var center = platformSpawnArea.GetAreaBounds().center;

        var randomXPosition = Random.Range(minAreaBounds.x, maxAreaBounds.x);

        return new Vector2(randomXPosition, center.y);
    }
}
