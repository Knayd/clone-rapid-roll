using UnityEngine;

public class Killer : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        HandleCollision(other.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        HandleCollision(other.gameObject);
    }

    private void HandleCollision(GameObject gameObject)
    {
        IKillable killableObject = gameObject.GetComponent<IKillable>();
        if (killableObject != null)
        {
            killableObject.Kill();
        }
    }
}
