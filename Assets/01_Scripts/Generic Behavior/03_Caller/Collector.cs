using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        ICollectable objectToCollect = other.gameObject.GetComponent<ICollectable>();
        if (objectToCollect != null)
        {
            objectToCollect.Collect();
        }
    }
}
