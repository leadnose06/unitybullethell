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
    private Vector3 goal;
    private float targetAngle;
    private float targetDistance;
    public GameObject self;
    
    
    
    
    

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
            Debug.Log("init angle"+ -(rotationSpeed * timer) % 360);
            spawner.GetComponent<SpawnerCode>().fire(-1f, true);
        }
        goal = Boss.transform.position;
        goal = new Vector3(goal.x+(distance*Mathf.Cos(angle)), goal.y+(distance*Mathf.Sin(angle)));
        
        
        targetAngle = Mathf.Atan((goal.y-gameObject.transform.position.y)/(goal.x-gameObject.transform.position.x));
        targetDistance = (0.0001f+(goal.y-gameObject.transform.position.y)*(1/Mathf.Sin(targetAngle)));
        if(targetDistance<=speed){
            gameObject.transform.position = goal;
        } else{
            gameObject.transform.position = new Vector3(Mathf.Cos(targetAngle)*speed, Mathf.Sin(targetAngle)*speed);
        }
        
        


    }
}
