using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;
    public Joystick joystick;
    private Animator animator;
    private Rigidbody2D rigidbody2D;
    private Vector2 moveInput;
    private Vector2 moveVelocity;

    private bool isFacingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = new Vector2(joystick.Horizontal, joystick.Vertical);
        moveVelocity = moveInput.normalized * speed;
        
        if (moveInput.x == 0 && moveInput.y == 0)
        {
            animator.SetBool("isRunning", false);
        }
        else
        {
            animator.SetBool("isRunning", true);
        }

        if (!isFacingRight && moveInput.x > 0 || isFacingRight && moveInput.x < 0)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        rigidbody2D.MovePosition(rigidbody2D.position + moveVelocity * Time.fixedDeltaTime);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
