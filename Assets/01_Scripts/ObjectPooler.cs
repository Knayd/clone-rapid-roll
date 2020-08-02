using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler SharedInstance;
    [SerializeField]
    private List<PoolableObjectConfig> poolableObjectConfigs;
    private List<GameObject> pooledObjects;

    void Awake()
    {
        SharedInstance = this;

        pooledObjects = new List<GameObject>();
        foreach (var config in poolableObjectConfigs)
        {
            for (int i = 0; i < config.GetAmountToPool(); i++)
            {
                GameObject newObject = Instantiate(config.GetObjectToPool());
                newObject.SetActive(false);
                pooledObjects.Add(newObject);
            }
        }
    }

    public GameObject GetPooledObject(string tag)
    {
        foreach (var pooledObject in pooledObjects)
        {
            if (!pooledObject.activeInHierarchy && pooledObject.CompareTag(tag))
            {
                return pooledObject;
            }
        }
        return null;
    }
}
