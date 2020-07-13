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
    void FixedUpdate()
    {

        //transform.position = new Vector2(startPosition.x, startPosition.y * movSpeed); 
        //transform.position = new Vector2(startPosition.x + Mathf.Sin(Time.time * speed), transform.position.y);
        Move();
        Destroy();
    }

    private void Move()
    {

        transform.position = new Vector2(startPosition.x, transform.position.y + Time.deltaTime * speed);
    }

    private void Destroy()
    {
        Vector2 ScreenBoundarie = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        if (transform.position.y >= ScreenBoundarie.y)
        {
            Destroy(gameObject);
        }
    }
}
