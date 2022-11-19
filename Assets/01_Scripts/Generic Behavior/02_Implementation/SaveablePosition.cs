using System;
using UnityEngine;

public class SaveablePosition : MonoBehaviour, ISaveable
{
    public object CaptureState()
    {
        var position = transform.position;
        return new SaveData
        {
            x = position.x,
            y = position.y,
            active = gameObject.activeInHierarchy
        };
    }

    public void RestoreState(object state)
    {
        var saveData = (SaveData)state;
        var isActive = saveData.active;
        gameObject.SetActive(isActive);
        if (isActive)
        {
            transform.position = new Vector3(saveData.x, saveData.y);
        }
    }

    [Serializable]
    private struct SaveData
    {
        public float x;
        public float y;
        public bool active;
    }
}
