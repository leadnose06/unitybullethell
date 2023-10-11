using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float dashSpeed;
    private bool dash;
    private bool immune;
    private float dashx;
    private float dashy;
    private float dashEnd;
    private bool dashReady;
    private float dashWhen;

    public Rigidbody2D player;

    Vector2 movement;
    void Start()
    {
        immune = false;
        dash = false;
        dashReady = true;
        player.position = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && dashReady)
        {
            dashEnd = dashControl();
            dash = true;
            dashReady = false;
            dashWhen = Time.time + 1f;
            immune = true;
        }
        if (Time.time >= dashEnd && dash)
        {
            dash = false;
            immune = false;
        }
        if (!dash)
        {
            movementInput();
        }
        if (Time.time >= dashWhen)
        {
            dashReady = true;
        }
    }

    private void FixedUpdate()
    {
        if (dash)
        {
            movement = new Vector2(dashx, dashy).normalized;
            player.velocity = movement * dashSpeed;
        }
        else
        {
            player.velocity = movement * moveSpeed;
        }
    }

    void movementInput()
    {
        float mx = Input.GetAxisRaw("Horizontal");
        float my = Input.GetAxisRaw("Vertical");

        movement = new Vector2(mx, my).normalized;
    }

    private float dashControl()
    {
        dashx = Input.GetAxisRaw("Horizontal");
        dashy = Input.GetAxisRaw("Vertical");
        return Time.time+0.2f;
    }
    
    
}
