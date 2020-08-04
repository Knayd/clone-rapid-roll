using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float moveSpeed = 7f;
    private Rigidbody2D rigidBody;
    private LevelManager levelManager;
    private const float DownwardsVelocityStartingPoint = -0.1f;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        levelManager = FindObjectOfType<LevelManager>();
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
            levelManager.IncreaseScore();
        }
    }

    private bool IsPlayerFalling() { return rigidBody.velocity.y < DownwardsVelocityStartingPoint; }

    void OnCollisionEnter2D(Collision2D other)
    {
        Collect(other.gameObject);
        Hurt(other.gameObject);
    }

    private void Collect(GameObject objectToCollect)
    {
        if (objectToCollect.CompareTag(Constants.TagLife))
        {
            objectToCollect.SetActive(false);
            levelManager.IncreaseLives();
        }
    }

    private void Hurt(GameObject spikes)
    {
        if (spikes.CompareTag(Constants.TagSpike))
        {
            levelManager.DecreaseLives();
            gameObject.SetActive(false);
        }
    }

}
