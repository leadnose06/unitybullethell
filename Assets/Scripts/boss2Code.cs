using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boss2Code : MonoBehaviour
{
    public GameObject[] phase1Spawners;
    public GameObject[] phase2SpawnersSpam;
    public GameObject[] phase2SpawnersRing;
    public double phase1Duration;
    public double phase2Duration;
    public double phase3Duration;
    private double timer;
    private bool phase1 = true;
    private bool phase2 = false;
    private bool phase3 = false;
    public double phase2RingFireRate;
    public double phase3SpamDuration;
    private double fireTimer;

    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject i in phase2SpawnersSpam)
        {
            i.GetComponent<SpawnerCode>().turnOnOrOff();
        }

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        fireTimer += Time.deltaTime;
        if(timer >= phase1Duration && phase1)
        {
            phase1 = false;
            phase2 = true;
            fireTimer = 0;
            foreach (GameObject i in phase2SpawnersRing)
            {
                i.GetComponent<SpawnerCode>().fire();
            }
        }
        if (timer >= phase2Duration && phase2)
        {
            phase2 = false;
            phase3 = true;
            foreach (GameObject i in phase2SpawnersRing)
            {
                i.GetComponent<SpawnerCode>().fire();
            }
            fireTimer = 0;

            foreach (GameObject i in phase2SpawnersSpam)
            {
                i.GetComponent<SpawnerCode>().turnOnOrOff();
            }
        }
        if(timer >= phase3Duration && phase3)
        {

            foreach (GameObject i in phase1Spawners)
            {
                i.GetComponent<SpawnerCode>().turnOnOrOff();
            }
            fireTimer = 0;

            foreach (GameObject i in phase2SpawnersSpam)
            {
                i.GetComponent<SpawnerCode>().turnOnOrOff();
            }
            phase3 = false;
        }
        if(phase2 && fireTimer >= phase2RingFireRate)
        {
            foreach (GameObject i in phase2SpawnersRing)
            {
                i.GetComponent<SpawnerCode>().fire();
            }
            fireTimer = 0;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            SceneManager.LoadScene(3);
        }
    }

}
