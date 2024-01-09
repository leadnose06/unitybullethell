using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boss1Code : MonoBehaviour
{
    private float initAngle;
    private float vx;
    private float vy;
    public float speed;
    public Rigidbody2D boss1;
    // Start is called before the first frame update
    void Start()
    {
        initAngle = Random.value * 2;
        vx = Mathf.Cos(initAngle);
        vy = Mathf.Sin(initAngle);
        boss1.velocity = new Vector2(speed * vx, speed * vy);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(0);
        }
    }
}
