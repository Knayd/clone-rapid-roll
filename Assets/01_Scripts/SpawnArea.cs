using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnArea : MonoBehaviour
{
    private List<GameObject> objectsInsideArea = new List<GameObject>();

    public List<GameObject> GetObjectsInsideArea()
    {
        return objectsInsideArea;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!objectsInsideArea.Contains(other.gameObject))
        {
            objectsInsideArea.Add(other.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        objectsInsideArea.Remove(other.gameObject);
    }
}
