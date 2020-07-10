﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    float moveSpeed = 5f;

    void Update()
    {
        Move();
    }

    private void Move()
    {

        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        var newXPos = transform.position.x + deltaX;
        var newYPos = transform.position.y + deltaY;

        transform.position = new Vector2(newXPos, newYPos);

    }
}