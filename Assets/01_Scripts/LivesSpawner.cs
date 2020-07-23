using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesSpawner : ObjectSpawnerOnTopOfPlatform
{

    [SerializeField] SpawnArea spawnArea;
    [SerializeField] GameObject lifeObject;
    private float maxTimeBetweenSpawns = 1f;
    private float minTimeBetweenSpawns = 4f;

    IEnumerator Start()
    {
        while (true)
        {
            // Spawn object indefinitely
            yield return StartCoroutine(SpawnObject());
        }
    }

    public override SpawnArea GetObjectSpawnArea()
    {
        return spawnArea;
    }

    public override GameObject GetObjectToSpawn()
    {
        return lifeObject;
    }

    public override float GetTimeInSecondsBetweenSpawns()
    {
        return Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
    }

    public override Vector2 ObjectToSpawnHalfHeight()
    {
        var lifeBounds = lifeObject.GetComponent<SpriteRenderer>().bounds;
        return new Vector2(0, lifeBounds.extents.y);
    }
}
