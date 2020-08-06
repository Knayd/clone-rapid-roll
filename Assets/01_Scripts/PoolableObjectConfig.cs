using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Poolable Object Config")]
public class PoolableObjectConfig : ScriptableObject
{
    [SerializeField] private GameObject objectToPool;
    [SerializeField] private int amountToPool;

    public GameObject GetObjectToPool() { return objectToPool; }

    public int GetAmountToPool() { return amountToPool; }
}
