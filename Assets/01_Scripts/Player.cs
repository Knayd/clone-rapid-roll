using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float moveSpeed = 7f;
    private Rigidbody2D rigidBody;
    private GameInfo gameInfo;
    private const float DownwardsVelocityStartingPoint = -0.1f;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        gameInfo = FindObjectOfType<GameInfo>();
    }

    void FixedUpdate()
    {
        Move();
        CheckPlayerState();
    }

    private void Move()
    {
        var direction = Input.GetAxis(Constants.HorizontalAxis);
        var distanceToMove = direction * moveSpeed;
        rigidBody.velocity = new Vector2(distanceToMove, rigidBody.velocity.y);
    }

    private void CheckPlayerState()
    {
        if (IsPlayerFalling())
        {
            gameInfo.IncreaseScore();
        }
    }

    private bool IsPlayerFalling() { return rigidBody.velocity.y < DownwardsVelocityStartingPoint; }

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
