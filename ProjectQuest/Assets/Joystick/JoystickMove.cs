using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMove : MonoBehaviour
{

    public Joystick movementJoystick;
    public float playerSpeed;
    private Rigidbody2D rb;
    Vector2 move;
    public bool isFacingRight = true;
    float scaleX;
    Vector3 currentScale;

    public Sprite standing, running;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        scaleX = (transform.localScale).x; // Calculates the initial x scale
    }

    private void Update() 
    {
        move.x = movementJoystick.Horizontal;
        move.y = movementJoystick.Vertical;

        float horizontalAxis = move.x;
        float verticalAxis = move.y;
        // zAxis calculates the direction the player is currently moving:
        //          UP 00
        // LEFT -90         90 RIGHT
        //    DOWN -180  180 DOWN
        float zAxis = Mathf.Atan2(horizontalAxis,verticalAxis) * Mathf.Rad2Deg;

        // Player is moving to the left (as zAxis is negative)
        if (zAxis < 0 && isFacingRight)
        {
            // If moving left and currently facing right, mirror the character
            MirrorCharacter();
        }
        else if (zAxis > 0 && !isFacingRight)
        {
            // If moving right and currently not facing right, unmirror the character
            UnmirrorCharacter();
        }

        // Update the character image based on the joystick input
        if (movementJoystick.Direction.y == 0) 
        {
            // The player is not moving, so the sprite image is a standing man.
            GetComponent<SpriteRenderer>().sprite = standing;
        }
        else 
        {
            // The player is moving, so the sprite image is a running man.
            GetComponent<SpriteRenderer>().sprite = running;
        }
    }

    private void FixedUpdate()
    {
        // Implements the boundaries of the map. These values must be changed depending
        // on the size of the character sprite. 
        // The current values are for a pixel stick man. Commented values are for a white box.
        if(transform.position.y >= 2.962f) // 4.4375f
        {
            transform.position = new Vector3(transform.position.x, 2.962f, -1.0f);
        }

        if(transform.position.y <= -2.962f) // -4.4375f
        {
            transform.position = new Vector3(transform.position.x, -2.926f, -1.0f);
        }

        if(transform.position.x >= 7.05f) // 10.0445f
        {
            transform.position = new Vector3(7.18f, transform.position.y, -1.0f);
        }

        if(transform.position.x <= -7.05f) // -10.0445f
        {
            transform.position = new Vector3(-7.18f, transform.position.y, -1.0f);
        }

        // Calculates the velocity of the movement
        if(movementJoystick.Direction.y != 0)
        {
            rb.velocity = new Vector2(movementJoystick.Direction.x * playerSpeed, movementJoystick.Direction.y * playerSpeed);
        } 
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    void MirrorCharacter()
    {
        // Mirror the character along the X-axis
        currentScale = transform.localScale;
        currentScale.x = -scaleX;
        transform.localScale = currentScale;
        isFacingRight = false;
    }

    void UnmirrorCharacter()
    {
        // Unmirror the character along the X-axis
        currentScale = transform.localScale;
        currentScale.x = scaleX;
        transform.localScale = currentScale;
        isFacingRight = true;
    }

}
