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
                var saveable = newObject.GetComponent<PoolableSaveable>();
                if (saveable != null && config.GetIds().Count > 0)
                {
                    saveable.SetId(config.GetIds()[i]);
                }

                pooledObjects.Add(newObject);
            }
        }
    }

    public GameObject GetPooledObject(string tag)
    {
        return pooledObjects.Find(pooledObject => !pooledObject.activeInHierarchy && pooledObject.CompareTag(tag));
    }
}
