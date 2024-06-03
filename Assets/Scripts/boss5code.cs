using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss5code : MonoBehaviour
{
    public GameObject spawnerPattern;
    private GameObject tempSpawner;
    private GameObject[] topRow = new GameObject[35];
    private GameObject[] bottomRow = new GameObject[35];
    private GameObject[] leftColumn = new GameObject[35];
    private GameObject[] rightColumn = new GameObject[35];
    private Vector3 tempPos;
    private float timer;
    private float fireTime;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        fireTime = 0;
        for(int i=0; i<35; i++){
            tempPos = new Vector3(18-(i+0.5f), 9.5f);
            tempSpawner = Instantiate(spawnerPattern, tempPos, Quaternion.identity);
            tempSpawner.GetComponent<SpawnerCode>().initAngle = Mathf.Rad2Deg*(Mathf.Atan2(tempPos.y, tempPos.x)+Mathf.PI);
            topRow[i] = tempSpawner;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= fireTime+10f){
            foreach(GameObject i in topRow){
                i.GetComponent<SpawnerCode>().fire();
            }
        }

    }
}
