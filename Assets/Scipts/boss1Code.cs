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
    private double timer2;
    public GameObject player;
    public GameObject[] phase12Spawners;
    public GameObject[] phase3Spawners;
    public PhysicsMaterial2D normal;
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
        timer2 += Time.deltaTime;
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
            for(int i=0; i<4; i++)
            {
                phase12Spawners[i].GetComponent<SpawnerCode>().turnOnOrOff();
                phase3Spawners[i].GetComponent<SpawnerCode>().turnOnOrOff();
            }
            gameObject.GetComponent<Rigidbody2D>().sharedMaterial = normal;
            phase2Move();
            
        }
        if ((gameObject.transform.position.x >= 15 || gameObject.transform.position.x <= -15 || gameObject.transform.position.y <= -7.5 || gameObject.transform.position.y >= 7.5) && !phase1 && timer2>=0.5)
        {
            phase2Move();
            timer2 = 0;
        }

    }

    private void phase2Move()
    {
        initAngle = Mathf.PI+Mathf.Atan((gameObject.transform.position.y - player.transform.position.y) / (gameObject.transform.position.x - player.transform.position.x));
        vx = Mathf.Cos(initAngle);
        vy = Mathf.Sin(initAngle);
        boss1.velocity = new Vector2(speed * vx*0.75f, speed * vy*0.75f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            SceneManager.LoadScene(0);
        }
        if (collision.gameObject.tag == "Boundary" && (phase2 || phase3))
        {
            boss1.velocity = new Vector2(0, 0);
            phase2Move();
        }
    }

}
