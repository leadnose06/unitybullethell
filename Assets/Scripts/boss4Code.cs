using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss4Code : MonoBehaviour
{
    private float timer = 0;
    public GameObject spawnedShooter;
    private GameObject[] shooters = new GameObject[6];
    // Start is called before the first frame update
    void Start()
    {
        for(int a=0; a<6; a++){
            shooters[a] = Instantiate(spawnedShooter);
            shooters[a].GetComponent<shooterCode>().angle = (2*Mathf.PI)/(a+1);
            shooters[a].GetComponent<shooterCode>().self = shooters[a];
            shooters[a].SetActive(true);
        }
        foreach(GameObject i in shooters){

        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        foreach(GameObject i in shooters){
            i.GetComponent<shooterCode>().distance = 5*Mathf.Sin(timer*2);
            i.GetComponent<shooterCode>().angle += ((2*Mathf.PI)*timer/20000)%(2*Mathf.PI);
        }
    }
}
