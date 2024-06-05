using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss5code : MonoBehaviour
{
    public GameObject spawnerPattern;
    private GameObject tempSpawner;
    private GameObject[] topRow = new GameObject[35];
    private GameObject[] bottomRow = new GameObject[35];
    private GameObject[] leftColumn = new GameObject[19];
    private GameObject[] rightColumn = new GameObject[19];
    private Vector3 tempPos;
    private float timer;
    private float fireTime;
    public float phase1Duration;
    public float phase2Duration;
    private bool phase1 = true;
    private bool phase2 = false;
    private bool phase3 = false;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        fireTime = 0;
        for(int i=0; i<35; i++){
            tempPos = new Vector3(18-(i+0.5f), 9.5f);
            tempSpawner = Instantiate(spawnerPattern, tempPos, Quaternion.identity);
            tempSpawner.GetComponent<SpawnerCode>().initAngle = Mathf.Rad2Deg*(Mathf.Atan2(-tempPos.y, tempPos.x)-(Mathf.PI*1.5f));
            topRow[i] = tempSpawner;
            tempPos = new Vector3(18-(i+0.5f), -9.5f);
            tempSpawner = Instantiate(spawnerPattern, tempPos, Quaternion.identity);
            tempSpawner.GetComponent<SpawnerCode>().initAngle = Mathf.Rad2Deg*(Mathf.Atan2(-tempPos.y, tempPos.x)-(Mathf.PI*1.5f));
            bottomRow[i] = tempSpawner;
        }
        for(int i=0; i<19; i++){
            tempPos = new Vector3(17.5f, 10f-(i+0.5f));
            tempSpawner = Instantiate(spawnerPattern, tempPos, Quaternion.identity);
            tempSpawner.GetComponent<SpawnerCode>().initAngle = Mathf.Rad2Deg*(Mathf.Atan2(-tempPos.y, tempPos.x)-(Mathf.PI*1.5f));
            rightColumn[i] = tempSpawner;
            tempPos = new Vector3(-17.5f, 10f-(i+0.5f));
            tempSpawner = Instantiate(spawnerPattern, tempPos, Quaternion.identity);
            tempSpawner.GetComponent<SpawnerCode>().initAngle = Mathf.Rad2Deg*(Mathf.Atan2(-tempPos.y, tempPos.x)-(Mathf.PI*1.5f));
            leftColumn[i] = tempSpawner;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer>=phase1Duration && phase1){
            phase1 = false;
            phase2 = true;
        }
        if(timer>=phase2Duration && phase2){
            phase2 = false;
            phase3 = true;
        }
        if(phase1 && timer >= fireTime+2.25f){
            for(int i=0; i<topRow.Length; i++){
                topRow[i].GetComponent<SpawnerCode>().fire(0.9f*(9.5f/10)*topRow[i].GetComponent<SpawnerCode>().speed/Mathf.Cos(Mathf.Deg2Rad*topRow[i].GetComponent<SpawnerCode>().initAngle));
                bottomRow[i].GetComponent<SpawnerCode>().fire(0.9f*(9.5f/10)* topRow[i].GetComponent<SpawnerCode>().speed/Mathf.Cos(Mathf.Deg2Rad*topRow[i].GetComponent<SpawnerCode>().initAngle));
            }
            for(int i=0; i<rightColumn.Length; i++){
                rightColumn[i].GetComponent<SpawnerCode>().fire(0.9f*(17.5f/10)*rightColumn[i].GetComponent<SpawnerCode>().speed/Mathf.Sin(Mathf.Deg2Rad*rightColumn[i].GetComponent<SpawnerCode>().initAngle));
                leftColumn[i].GetComponent<SpawnerCode>().fire(0.9f*(17.5f/10)*rightColumn[i].GetComponent<SpawnerCode>().speed/Mathf.Sin(Mathf.Deg2Rad*rightColumn[i].GetComponent<SpawnerCode>().initAngle));
            }
            fireTime = timer;
        }


    }
}
