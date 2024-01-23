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
    public double phase1Duration;
    public double phase2Duration;
    private bool phase1 = true;
    private bool phase2 = false;
    private bool phase3 = false;
    private double timer;
    public GameObject player;
    public GameObject[] phase12Spawners;
    public GameObject[] phase3Spawners;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        initAngle = Random.value * 2;
        vx = Mathf.Cos(initAngle);
        vy = Mathf.Sin(initAngle);
        boss1.velocity = new Vector2(speed * vx, speed * vy);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= phase1Duration && phase1)
        {
            phase1 = false;
            phase2 = true;
            phase2Move();
        }
        if (timer >= phase2Duration && phase2)
        {
            phase2 = false;
            phase3 = true;
            phase2Move();
        }

    }

    private void phase2Move()
    {
        initAngle = Mathf.Atan((gameObject.transform.position.y - player.transform.position.y) / (gameObject.transform.position.x - player.transform.position.x));
        vx = Mathf.Cos(initAngle);
        vy = Mathf.Sin(initAngle);
        boss1.velocity = new Vector2(speed * vx, speed * vy);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(0);
        }
        if (collision.gameObject.tag == "Boundary" && (phase2 || phase3))
        {
            phase2Move();
        }
    }

}
