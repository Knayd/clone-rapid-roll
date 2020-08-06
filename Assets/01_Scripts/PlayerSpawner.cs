using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : ObjectSpawnerOnTopOfPlatform
{
    [SerializeField] 
    private SpawnArea spawnArea;

    public override SpawnArea GetObjectSpawnArea()
    {
        return spawnArea;
    }

    public override GameObject GetObjectToSpawn()
    {
        return ObjectPooler.SharedInstance.GetPooledObject(Constants.TagPlayer);
    }

    public override float GetTimeInSecondsBetweenSpawns()
    {
        return 1f;
    }
}
