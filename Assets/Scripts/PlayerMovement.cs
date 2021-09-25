using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using Mirror;

/// <summary>
/// Handles moving of player
/// </summary>
public class PlayerMovement : NetworkBehaviour
{
    public float speed;
    public float jump = 20f;
    public Transform feet;
    public LayerMask groundLayers;
    public bool isNetworked = false; //to distinguish if this script is run in networked enviroment

    private bool facingRight = true;
    float movementX;
    Rigidbody2D rb;

    /// <summary>
    /// Gets info needed (rigidbody)
    /// </summary>
    void Start()
    {
        //PlayerInput = new PlayerInputScript();
        rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Not currently in use
    /// </summary>
    void OnEnable()
    {
        //PlayerInput.Enable();
    }
    void OnDisable()
    {
        //PlayerInput.Disable();
    }
    // Update is called once per frame

    /// <summary>
    /// Gets triggered, when we press keys for move
    /// </summary>
    /// <param name="context">Info from input manager</param>
    public void OnMove(InputAction.CallbackContext context)
    {
        movementX = context.ReadValue<float>();
    }


    /// <summary>
    /// Gets triggered, when we press button to jump
    /// </summary>
    /// <param name="context"></param>
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.action.triggered)
        {
            Jump();
        }
    }


    /// <summary>
    /// Update used only in networked scenario, because we use there different input system
    /// </summary>
    void Update()
    {
        //movementX = PlayerInput.Basic.Movement.ReadValue<float>();
        //Vector3 currentPosition = transform.position;
        //currentPosition.x += movementX * speed * Time.deltaTime;
        //transform.position = currentPosition;

        if (isNetworked && isLocalPlayer)
        {
            movementX = Input.GetAxisRaw("Horizontal");
            if (Input.GetKeyDown(KeyCode.W) && TouchesGround())
            {
                Jump();
            }
        }

    }

    /// <summary>
    /// Handles moving of player
    /// </summary>
    void FixedUpdate()
    {
        if (movementX < 0 && facingRight) //starts moving in the opoite direction
        {
            Flip();
        }
        else if (movementX > 0 && !facingRight)
        {
            Flip();
        }
        Vector2 movement = new Vector2(movementX * speed, rb.velocity.y);
        rb.velocity = movement;
    }

    /// <summary>
    /// Jumps player
    /// </summary>
    void Jump()
    {
        if (TouchesGround())
        {
            //Vector2 movement = new Vector2(rb.velocity.x, jump);
            //rb.velocity = movement;
            rb.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
        }
        
    }

    /// <summary>
    /// Checks, if we are touching ground, so we dont jump till infinity
    /// </summary>
    /// <returns>True if we touch ground by feet</returns>
    bool TouchesGround()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayers);
        if (groundCheck != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Makes player face the other way around, incluting weapon
    /// </summary>
    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    /// <summary>
    /// Sets player to face right
    /// </summary>
    public void FaceRight()
    {
        if (!facingRight)
        {
            Flip();
        }
    }
}
