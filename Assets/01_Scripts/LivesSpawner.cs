using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesSpawner : ObjectSpawnerOnTopOfPlatform
{

    [SerializeField] SpawnArea spawnArea;
    private float maxTimeBetweenSpawns = 4f;
    private float minTimeBetweenSpawns = 1f;

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
        return ObjectPooler.SharedInstance.GetPooledObject(Constants.TagLife);
    }

    public override float GetTimeInSecondsBetweenSpawns()
    {
        return Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
    }
}
