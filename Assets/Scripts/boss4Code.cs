using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss4Code : MonoBehaviour
{
    private float timer = 0;
    public GameObject spawnedShooter;
    private GameObject[] shooters = new GameObject[6];
    public float phase1Duration;
    public float phase2Duration;
    public float phase3Duration;
    private bool phase1 = true;
    private bool phase2 = false;
    private bool phase3 = false;
    private bool outwards;
    private bool fullOut;
    private float outTime;
    // Start is called before the first frame update
    void Start()
    {
        for(int a=0; a<6; a++){
            shooters[a] = Instantiate(spawnedShooter);
            shooters[a].GetComponent<shooterCode>().angle = (2*Mathf.PI)/6*(1+a);
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
        if(timer >= phase1Duration && phase1){
            phase1 = false;
            phase2 = true;
            outwards = false;
            fullOut = false;
        }
        if(timer >= phase1Duration + phase2Duration && phase2){
            phase2 = false;
            phase3 = true;
        }
        if(timer >= phase1Duration + phase2Duration + phase3Duration && phase3){

        }
        if(phase2 && Mathf.Abs(shooters[0].GetComponent<shooterCode>().distance) <= 0.1){
            outwards = true;
        }
        if(phase2 && outwards && 20*Mathf.Abs(Mathf.Sin((timer)%(2*Mathf.PI))) >= 19.9 &! fullOut){
            foreach(GameObject i in shooters){
                i.GetComponent<shooterCode>().distance = 20;
            }
            outTime = timer;
            fullOut = true;
        }
        if(fullOut && 20*Mathf.Abs(Mathf.Sin((timer)%(2*Mathf.PI))) >= 19.9){
            fullOut = false;
            outwards = false;
        }
        foreach(GameObject i in shooters){
            if(phase2 && outwards &! fullOut){
                i.GetComponent<shooterCode>().distance = 20*Mathf.Abs(Mathf.Sin((timer)%(2*Mathf.PI)));
            } else if(phase2 &! fullOut){
                i.GetComponent<shooterCode>().distance = 20*Mathf.Abs(Mathf.Sin((timer)%(2*Mathf.PI)));
            } else if(!fullOut){
                i.GetComponent<shooterCode>().distance = 3*Mathf.Abs(Mathf.Sin((timer*2)%(2*Mathf.PI)));
            }
            if(phase2){
                i.GetComponent<shooterCode>().angle += (60*(Mathf.PI/30))*Time.deltaTime;
            } else{
                i.GetComponent<shooterCode>().angle += (15*(Mathf.PI/30))*Time.deltaTime;
            }
        }

    }
}
