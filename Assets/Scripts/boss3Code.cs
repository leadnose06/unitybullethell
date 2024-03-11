using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boss3Code : MonoBehaviour
{
    public GameObject spam;
    private GameObject[] spamArray = new GameObject[39];
    private GameObject addSpawner;
    private bool phase1 = true;
    private bool phase2 = false;
    private bool phase3 = false;
    public float phase1Duration;
    public float phase2Duration;
    public float phase3Duration;
    private int ticker1 = 0;
    private int ticker2 = 38;
    private float timer;
    public float phase1FireRate;
    public float phase2FireRate;
    private float lastShot = 0;
    private int gapCenter;
    private float gapDelay = 0.7f;
    private bool gapDecrease = false;
    private float lineDelay;
    private float gapLength;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 39; i++)
        {
            spamArray[i] = Instantiate(spam, new Vector3(15.75f, i), Quaternion.identity);
            spamArray[i].GetComponent<SpawnerCode>().offsetY = spam.GetComponent<SpawnerCode>().offsetY-0.5f*i;
            spamArray[i].SetActive(true);
        }
        lastShot = 0.1f;

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (phase1)
        {
            if(timer >= lastShot + phase1FireRate)
            {
                lastShot = timer;
                spamArray[ticker1].GetComponent<SpawnerCode>().fire();
                spamArray[ticker2].GetComponent<SpawnerCode>().fire();
                ticker1++;
                ticker2--;
                if (ticker1 > 38)
                {
                    ticker1 = 0;
                    ticker2 = 38;
                }
            }
        }
        if(timer >= phase1Duration && phase1)
        {
            phase1 = false;
        }
        if(timer >= phase1Duration + 1 && !phase2 && !phase3)
        {
            phase2 = true;
            gapCenter = 17;
            gapDelay = timer + 0.8f;
            lineDelay = timer = 2.5f;
            if (Random.value > 0.5f)
            {
                gapDecrease = true;
            }
        }
        if(timer >= phase2Duration && phase2)
        {
            phase2 = false;
            phase3 = true;
            gapDelay = timer + 0.5f;
            gapLength = timer + 0.4f;

        }
        if (phase2)
        {   
            if(timer >= lineDelay)
            {
                lineDelay = timer + 3f;
                for (int i = 0; i < 39; i++)
                {
                    spamArray[i].GetComponent<SpawnerCode>().fire(700);
                }
            }
            if (timer >= lastShot + phase2FireRate)
            {
                for (int i = 0; i < 39; i++)
                {
                    if (!((i > gapCenter - 6) && (i < gapCenter + 6)))
                    {
                        spamArray[i].GetComponent<SpawnerCode>().fire();
                    }
                }
                lastShot = timer;
            }
            
            if(timer >= gapDelay)
            {
                if (Random.value > 0.8f)
                {
                    gapDecrease = !gapDecrease;
                }
                if(gapCenter-6 <= 1)
                {
                    gapDecrease = false;
                }
                if(gapCenter+6 >= 37)
                {
                    gapDecrease = true;
                }
                if (gapDecrease)
                {
                    gapCenter -= 2;
                }
                else
                {
                    gapCenter += 2;
                }
                gapDelay = timer + 0.8f;
            }
        }
        if (phase3)
        {
            if (timer >= lastShot + phase2FireRate)
            {
                for (int i = 0; i < 39; i++)
                {
                    if ((!((i > gapCenter - 5) && (i < gapCenter + 5))) || timer >= gapLength)
                    {
                        spamArray[i].GetComponent<SpawnerCode>().fire();
                    }
                }
                lastShot = timer;
            }
            if (timer >= gapDelay)
            {
                if(gapCenter + 5 >= 37)
                {
                    gapCenter -= 8;
                }
                else if(gapCenter - 5 <= 1)
                {
                    gapCenter += 8;
                }
                else if (Random.value > 0.5)
                {
                    gapCenter += 8;
                }
                else
                {
                    gapCenter -= 8;
                }
                gapDelay = timer + 1.7f;
                gapLength = timer + 1.5f;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
