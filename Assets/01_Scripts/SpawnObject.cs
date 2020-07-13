using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] private GameObject Platform;
    [SerializeField] private float TimeBetweenSpawns;
   
    Vector2 SpawnerPosition;
    void Start()
    {
        
        SpawnerPosition = new Vector2(transform.position.x, transform.position.y);
        
        
        StartCoroutine(Spawning());
    }

   

    private IEnumerator Spawning()
    {
        while (true) {
            
            GameObject A = (GameObject)Instantiate(Platform);
            A.transform.parent = transform;
            A.transform.position = SpawnerPosition;
            TimeBetweenSpawns = Random.Range(1, 10);
            yield return new WaitForSeconds(TimeBetweenSpawns);
       

        }

    }
}
