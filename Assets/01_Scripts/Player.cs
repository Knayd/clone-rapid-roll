using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Constants
    private const string HorizontalAxis = "Horizontal";

    private float moveSpeed = 7f;
    Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        var direction = Input.GetAxis(HorizontalAxis);
        var distanceToMove = direction * moveSpeed;
        rigidBody.velocity = new Vector2(distanceToMove, rigidBody.velocity.y);
    }
}
