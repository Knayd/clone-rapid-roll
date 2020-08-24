using UnityEngine;

public class Despawnable : MonoBehaviour, IDespawnable
{
    public void Despawn()
    {
        this.gameObject.SetActive(false);
    }
}
