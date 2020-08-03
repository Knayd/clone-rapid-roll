using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] SpawnArea platformSpawnArea;
    private float minSpawnTime = 2f;
    private float maxSpawnTime = 4f;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            string platformTag;

            // 70% chance of getting a normal platform
            platformTag = (Random.value <= 0.7) ? Constants.TagPlatform : Constants.TagSpike;

            GameObject platform = ObjectPooler.SharedInstance.GetPooledObject(platformTag);

            if (platform != null)
            {
                platform.transform.position = GetPositionToSpawn();
                platform.SetActive(true);
            }
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
        }
    }

    private Vector2 GetPositionToSpawn()
    {
        var minAreaBounds = platformSpawnArea.GetAreaBounds().min;
        var maxAreaBounds = platformSpawnArea.GetAreaBounds().max;
        var center = platformSpawnArea.GetAreaBounds().center;

        var randomXPosition = Random.Range(minAreaBounds.x, maxAreaBounds.x);

        return new Vector2(randomXPosition, center.y);
    }
}
