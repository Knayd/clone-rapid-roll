using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Poolable Object Config")]
public class PoolableObjectConfig : ScriptableObject
{
    [SerializeField] private GameObject objectToPool;
    [SerializeField] private int amountToPool;
    [SerializeField] private List<string> ids;

    [ContextMenu("Generate Ids")]
    private void GenerateIds()
    {
        ids.Clear();
        for (int i = 0; i < GetAmountToPool(); i++)
        {
            ids.Add(Guid.NewGuid().ToString());
        }
    }

    public GameObject GetObjectToPool() { return objectToPool; }

    public int GetAmountToPool() { return amountToPool; }

    public List<string> GetIds() => ids;

}
