using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Poolable Object")]
public class PoolableObject : ScriptableObject
{
    [SerializeField] private GameObject objectToPool;
    [SerializeField] private int amountToPool;

    public GameObject GetObjectToPool() { return objectToPool; }

    public int GetAmountToPool() { return amountToPool; }
}
