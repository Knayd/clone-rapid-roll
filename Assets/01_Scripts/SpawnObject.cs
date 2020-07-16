using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] private GameObject[] Prefabs;
    [SerializeField] private float TimeBetweenSpawns;
    [SerializeField] int arrayCounter;

    private int randomPrefab;

    Vector2 SpawnerPosition;
    void Start()
    {
        arrayCounter = Prefabs.Length;
        SpawnerPosition = new Vector2(transform.position.x, transform.position.y);
        
        
        StartCoroutine(Spawning());
    }

   

    private IEnumerator Spawning()
    {
        while (true) {

            randomPrefab = Random.Range(0, arrayCounter);
            GameObject storeTemporalPrefabs = (GameObject)Instantiate(Prefabs[randomPrefab]); //Store in this var the instantiated in game prefabs
            storeTemporalPrefabs.transform.parent = transform;
            storeTemporalPrefabs.transform.position = SpawnerPosition;
            TimeBetweenSpawns = Random.Range(1, 10);
            yield return new WaitForSeconds(TimeBetweenSpawns);
       

        }

    }
}
