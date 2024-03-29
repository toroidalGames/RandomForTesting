﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;

    Rigidbody2D rigidbody;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        float leftOrRightInput = CrossPlatformInputManager.GetAxis("Horizontal");
        float upOrDownInput = CrossPlatformInputManager.GetAxis("Vertical");
        Vector2 movementVelocity = new Vector2(leftOrRightInput * moveSpeed, upOrDownInput * moveSpeed);
        rigidbody.velocity = movementVelocity;
    }
}
