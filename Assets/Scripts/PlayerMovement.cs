using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //private PlayerInputScript PlayerInput;
    Rigidbody2D rb;
    public float speed;
    public float jump = 20f;
    float movementX;
    public Transform feet;
    public LayerMask groundLayers;
    private bool facingRight = true;
    void Start()
    {
        //PlayerInput = new PlayerInputScript();
        rb = GetComponent<Rigidbody2D>();
    }
    void OnEnable()
    {
        //PlayerInput.Enable();
    }
    void OnDisable()
    {
        //PlayerInput.Disable();
    }
    // Update is called once per frame

    public void OnMove(InputAction.CallbackContext context)
    {
        //Debug.Log("moving");
        movementX = context.ReadValue<float>();
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.action.triggered)
        {
            Jump();
        }
    }
    void Update()
    {
        //movementX = PlayerInput.Basic.Movement.ReadValue<float>();
        //Vector3 currentPosition = transform.position;
        //currentPosition.x += movementX * speed * Time.deltaTime;
        //transform.position = currentPosition;
        /*
        movementX = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump") && TouchesGround())
        {
            Jump();
        }*/
    }
    void FixedUpdate()
    {
        if (movementX < 0 && facingRight)
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
    void Jump()
    {
        if (TouchesGround())
        {
            //Vector2 movement = new Vector2(rb.velocity.x, jump);
            //rb.velocity = movement;
            rb.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
        }
        
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
    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
    public void FaceRight()
    {
        if (!facingRight)
        {
            Flip();
        }
    }
}
