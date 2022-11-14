using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveablePosition : MonoBehaviour, ISaveable
{
    public object CaptureState()
    {
        var position = transform.position;
        return new Position
        {
            x = position.x,
            y = position.y
        };
    }

    public void RestoreState(object state)
    {
        var position = (Position)state;
        transform.position = new Vector3(position.x, position.y);
    }

    [Serializable]
    private struct Position
    {
        public float x;
        public float y;
    }
}
