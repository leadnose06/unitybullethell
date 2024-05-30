using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooterCode : MonoBehaviour
{
    private GameObject spawner;
    public GameObject spawnerPattern;
    public GameObject Boss;
    public float rotationSpeed;
    public float setSpeed;
    private float speed;
    public float fireRate;
    private float fireWait;
    public float initDelay = 0f;
    public float test;
    private float timer;
    public float angle;
    public float distance; 
    public Vector3 goal;
    private float targetAngle;
    private float targetDistance;
    public GameObject self;
    public bool goalSet = false;
    public bool shooting = true;
    
    
    
    
    
    

    //private GameObject[] spawners;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        fireWait = fireRate + initDelay;
        speed = setSpeed;
        spawner = Instantiate(spawnerPattern);
        spawner.GetComponent<SpawnerCode>().attached = self;

    }

    // Update is called once per frame
    void Update()
    {
        speed = setSpeed*Time.deltaTime;
        timer += Time.deltaTime;
        gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y, gameObject.transform.eulerAngles.z + (rotationSpeed * Time.deltaTime));
        if(timer >= fireWait)
        {
            fireWait = timer + fireRate;
            spawner.GetComponent<SpawnerCode>().initAngle = -(rotationSpeed * timer) % 360;
            if(shooting)
            {
                spawner.GetComponent<SpawnerCode>().fire(-1f, true);
            }
        }
        if(!goalSet){
           goal = Boss.transform.position;
        }
        goal = new Vector3(goal.x+(distance*Mathf.Cos(angle)), goal.y+(distance*Mathf.Sin(angle)));
        
        transform.position = goal;
        
        


    }

    
}
