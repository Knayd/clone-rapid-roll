using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampUpMovement : MonoBehaviour
{
    [SerializeField] float speed;
    Vector2 startPosition;

    void Start()
    {
        startPosition = transform.position;
        speed = .5f;
    }

    void Update()
    {
        Move();
        Destroy();
    }

    private void Move()
    {
        transform.position = new Vector2(startPosition.x, transform.position.y + Time.deltaTime * speed);
    }

    private void Destroy()
    {
        Vector2 screenBoundary = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        if (transform.position.y >= screenBoundary.y)
        {
            gameObject.SetActive(false);
        }
    }
}
