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
            GameObject A = (GameObject)Instantiate(Prefabs[randomPrefab]);
            A.transform.parent = transform;
            A.transform.position = SpawnerPosition;
            TimeBetweenSpawns = Random.Range(1, 10);
            yield return new WaitForSeconds(TimeBetweenSpawns);
       

        }

    }
}
