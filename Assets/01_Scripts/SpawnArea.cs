using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnArea : MonoBehaviour
{
    private Bounds areaBounds;
    private List<Collider2D> collidersInsideArea = new List<Collider2D>();

    void Awake()
    {
        areaBounds = GetComponent<Collider2D>().bounds;
    }

    public Bounds GetAreaBounds() { return areaBounds; }

    public List<Collider2D> GetCollidersInsideArea()
    {
        return collidersInsideArea;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!collidersInsideArea.Contains(other))
        {
            collidersInsideArea.Add(other);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        collidersInsideArea.Remove(other);
    }
}
