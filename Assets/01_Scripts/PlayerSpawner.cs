using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : ObjectSpawnerOnTopOfPlatform
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

    public override float GetTimeInSecondsBetweenSpawns()
    {
        return 1f;
    }

    public override Vector2 ObjectToSpawnHalfHeight()
    {
        // Using sprite renderer here due to object starting as inactive
        var playerBounds = player.GetComponent<SpriteRenderer>().bounds;
        return new Vector2(0, playerBounds.extents.y);
    }
}
