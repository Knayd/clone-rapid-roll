using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : BaseObjectSpawner
{
    [SerializeField] SpawnArea spawnArea;
    [SerializeField] GameObject player;

    void Start()
    {
        StartCoroutine(SpawnObject());
    }

    public override SpawnArea GetObjectSpawnArea()
    {
        return spawnArea;
    }

    public override GameObject GetObjectToSpawn()
    {
        return player;
    }

    public override string GetObjectTagOnWhichToSpawn()
    {
        return Constants.TagPlatform;
    }

    public override float GetTimeBetweenSpawns()
    {
        return 1f;
    }
}
