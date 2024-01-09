using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private SpriteRenderer square;
    private float transparency = 1f;
    public float startx = 0;
    public float starty = 0;
    public bool nobullet = false;

    public Rigidbody2D player;

    Vector2 movement;
    void Start()
    {
        immune = false;
        dash = false;
        dashReady = true;
        player.position = new Vector2(startx, starty);
        square = GetComponent<SpriteRenderer>();
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
            transparency = 1f;
            square.color = new Color(square.color.r, square.color.g, square.color.b, transparency);
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
        if (nobullet)
        {
            immune = true;
        }
        if (dash)
        {
            if(transparency>0.4f && dashEnd - Time.time > 0.2f)
            {
                transparency -= 0.15f;
            }else if(transparency < 1f && dashEnd - Time.time <= 0.075f)
            {
                transparency += 0.15f;
            }
            square.color = new Color(square.color.r, square.color.g, square.color.b, transparency);
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
        return Time.time+0.3f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet" && !immune)
        {
            SceneManager.LoadScene(0);
        }
    }




}
