using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooterCode : MonoBehaviour
{
    public GameObject spawner;
    public GameObject Boss;
    public float rotationSpeed;
    public float speed;
    public float fireRate;
    private float fireWait;
    public float initDelay = 0f;
    public float test;
    private float timer;
    public float angle;
    public float distance = -1; 
    private Vector3 goal;
    
    
    
    

    //private GameObject[] spawners;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        fireWait = fireRate + initDelay;

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y, gameObject.transform.eulerAngles.z + (rotationSpeed * Time.deltaTime));
        if(timer >= fireWait)
        {
            fireWait = timer + fireRate;
            spawner.GetComponent<SpawnerCode>().initAngle = -(rotationSpeed * timer) % 360;
            Debug.Log("init angle"+ -(rotationSpeed * timer) % 360);
            spawner.GetComponent<SpawnerCode>().fire(-1f, true);
        }
        goal = Boss.transform.position;
        if(gameObject.transform.position!=goal){
            di
        }
        


    }
}
