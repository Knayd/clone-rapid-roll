using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOtherOnCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        Deactivate(other.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Deactivate(other.gameObject);
    }

    private void Deactivate(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
}
