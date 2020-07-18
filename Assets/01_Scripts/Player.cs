using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
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
        var direction = Input.GetAxis(Constants.HorizontalAxis);
        var distanceToMove = direction * moveSpeed;
        rigidBody.velocity = new Vector2(distanceToMove, rigidBody.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Colletc(other.gameObject);
    }

    private void Colletc(GameObject objectToCollect)
    {
        if (objectToCollect.CompareTag(Constants.TagLife))
        {
            objectToCollect.SetActive(false);
            //TODO: Add code for one-up here.
        }
    }
}
