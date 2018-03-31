﻿using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Range(0, 100)]
    public float speed = 5f;

    private Rigidbody2D body2d;
    private Vector2 movementVector;
    private Animator anim;

    // Use this for initialization
    private void Start()
    {
        body2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Update()
    {
        //movement with the axis of the xbox gamepad
        movementVector.x = Input.GetAxisRaw("Horizontal") * speed;
        movementVector.y = Input.GetAxisRaw("Vertical") * speed;

        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            this.anim.SetBool("IsWalking", true);
            this.anim.SetFloat("MoveX", movementVector.x);
            this.anim.SetFloat("MoveY", movementVector.y);
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }
    }

    public void FixedUpdate()
    {
        body2d.velocity = new Vector2(movementVector.x, movementVector.y);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, movementVector.normalized);
    }
}