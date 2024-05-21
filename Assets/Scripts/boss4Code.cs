using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss4Code : MonoBehaviour
{
    private float timer = 0;
    public GameObject spawnedShooter;
    private GameObject[] shooters = new GameObject[12];
    public float phase1Duration;
    public float phase2Duration;
    public float phase3Duration;
    private bool phase1 = true;
    private bool phase2 = false;
    private bool phase3 = false;
    private bool outwards;
    private bool fullOut;
    private float outTime;
    private bool returned;
    private Vector3 goal;
    // Start is called before the first frame update
    void Start()
    {
        for(int a=0; a<12; a++){
            shooters[a] = Instantiate(spawnedShooter);
            shooters[a].GetComponent<shooterCode>().angle = (2*Mathf.PI)/6*(1+a);
            shooters[a].GetComponent<shooterCode>().self = shooters[a];
            shooters[a].SetActive(true);
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
            returned = false;
        }
        if(timer >= phase1Duration + phase2Duration && phase2 && Mathf.Cos((timer)%(2*Mathf.PI))<=0.05){
            phase2 = false;
            phase3 = true;
            foreach(GameObject i in shooters){
                i.GetComponent<shooterCode>().goalSet = true;
                i.GetComponent<shooterCode>().fireRate = 1.1f;
            }
            goal = new Vector3(Mathf.Cos((timer*2)%(2*Mathf.PI)), Mathf.Sin((timer*2)%(2*Mathf.PI)));
        }
        if(timer >= phase1Duration + phase2Duration + phase3Duration && phase3){

        }
        if(phase2 && Mathf.Abs(shooters[0].GetComponent<shooterCode>().distance) <= 0.2 && !outwards){
            outwards = true;
            returned = true;
            outTime = timer;
        }
        if(returned && timer >= outTime+0.25f && Mathf.Abs(Mathf.Sin(timer))<=0.05){
            returned = false;
        }
        if(phase2 && outwards && 20*Mathf.Abs(Mathf.Sin((timer)%(2*Mathf.PI))) >= 19.9 &! fullOut){
            foreach(GameObject i in shooters){
                i.GetComponent<shooterCode>().distance = 20;
            }
            fullOut = true;
        }
        if(fullOut && 20*Mathf.Abs(Mathf.Sin((timer)%(2*Mathf.PI))) >= 19.9){
            fullOut = false;
            outwards = false;
        }
        /*foreach(GameObject i in shooters){
            if(phase2 && returned){
                i.GetComponent<shooterCode>().distance = 20*Mathf.Abs(Mathf.Sin((timer)%(2*Mathf.PI)));
            } else if(!fullOut){
                i.GetComponent<shooterCode>().distance = 3*Mathf.Abs(Mathf.Sin((timer*2)%(2*Mathf.PI)));
            }
            if(phase2 && outwards){
                i.GetComponent<shooterCode>().angle += (60*(Mathf.PI/30))*Time.deltaTime;
            } else if(phase3)
            {
                i.GetComponent<shooterCode>().angle += (50*(Mathf.PI/30))*Time.deltaTime;
            }else{
                i.GetComponent<shooterCode>().angle += (10*(Mathf.PI/30))*Time.deltaTime;
            }
        }
        if(phase3){
            int index = 0;
            foreach(GameObject i in shooters){
                if(index > 5){
                    goal = new Vector3(-5*Mathf.Cos((timer*4)%(2*Mathf.PI)), -5*Mathf.Sin((timer*4)%(2*Mathf.PI)));
                }else{
                    goal = new Vector3(5*Mathf.Cos((timer*4)%(2*Mathf.PI)), 5*Mathf.Sin((timer*4)%(2*Mathf.PI)));
                }
                i.GetComponent<shooterCode>().goal = goal;
                index++;
            }
        }*/
        int index = 0;
        foreach(GameObject i in shooters){
            if(phase2 && returned){
                i.GetComponent<shooterCode>().distance = 20*Mathf.Abs(Mathf.Sin((timer)%(2*Mathf.PI)));
            } else if(!fullOut){
                i.GetComponent<shooterCode>().distance = 3*Mathf.Abs(Mathf.Sin((timer*2)%(2*Mathf.PI)));
            }
            if(phase2 && outwards){
                i.GetComponent<shooterCode>().angle += (60*(Mathf.PI/30))*Time.deltaTime;
            } else if(phase3)
            {
                i.GetComponent<shooterCode>().angle += (50*(Mathf.PI/30))*Time.deltaTime;
            }else{
                i.GetComponent<shooterCode>().angle += (10*(Mathf.PI/30))*Time.deltaTime;
            }
            if(phase3){
                if(index > 5){
                    goal = new Vector3(-5*Mathf.Cos((timer*4)%(2*Mathf.PI)), -5*Mathf.Sin((timer*4)%(2*Mathf.PI)));
                }else{
                    goal = new Vector3(5*Mathf.Cos((timer*4)%(2*Mathf.PI)), 5*Mathf.Sin((timer*4)%(2*Mathf.PI)));
                }
                i.GetComponent<shooterCode>().goal = goal;
            }
            index++;
        }    
        

    }
}
