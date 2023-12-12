using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMove : MonoBehaviour
{
    
    public Joystick movementJoystick;
    public float playerSpeed;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {

        if(transform.position.y >= 4.4375f)
        {
            transform.position = new Vector3(transform.position.x, 4.4375f, 0.0f);
        }

        if(transform.position.y <= -4.4375f)
        {
            transform.position = new Vector3(transform.position.x, -4.4375f, 0.0f);
        }

        if(transform.position.x >= 10.0445f)
        {
            transform.position = new Vector3(10.0445f, transform.position.y, 0.0f);
        }

        if(transform.position.x <= -10.0445f)
        {
            transform.position = new Vector3(-10.0445f, transform.position.y, 0.0f);
        }

        if(movementJoystick.Direction.y != 0)
        {
            rb.velocity = new Vector2(movementJoystick.Direction.x * playerSpeed, movementJoystick.Direction.y * playerSpeed);
        } else
        {
            rb.velocity = Vector2.zero;
        }
    }

}
