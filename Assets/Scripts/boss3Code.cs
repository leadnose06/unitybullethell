using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private float lastShot = 0;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 39; i++)
        {
            spamArray[i] = Instantiate(spam, new Vector3(15.75f, i), Quaternion.identity);
            spamArray[i].GetComponent<SpawnerCode>().offsetY = spam.GetComponent<SpawnerCode>().offsetY-0.5f*i;
            spamArray[i].SetActive(true);
        }

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
    }
}
