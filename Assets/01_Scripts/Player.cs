using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";

    float moveSpeed = 5f;

    Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        rigidBody.freezeRotation = true;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {

        var deltaX = Input.GetAxis(HorizontalAxis) * Time.deltaTime * moveSpeed;
        var newXPos = transform.position.x + deltaX;
        transform.position = new Vector2(newXPos, transform.position.y);
    }

}
