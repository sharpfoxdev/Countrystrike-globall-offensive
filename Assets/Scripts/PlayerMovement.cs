using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float jump = 20f;
    float movementX;
    public Transform feet;
    public LayerMask groundLayers;

    // Update is called once per frame
    void Update()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump") && TouchesGround())
        {
            Jump();
        }
    }
    void FixedUpdate()
    {
        Vector2 movement = new Vector2(movementX * speed, rb.velocity.y);
        rb.velocity = movement;
    }
    void Jump()
    {
        Vector2 movement = new Vector2(rb.velocity.x, jump);
        rb.velocity = movement;
    }
    bool TouchesGround()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayers);//what, how far with what
        if (groundCheck != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
