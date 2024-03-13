using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooterCode : MonoBehaviour
{
    public GameObject spawner;
    public float rotationSpeed;
    public float fireRate;
    private float fireWait;
    public float initDelay = 0f;
    private float timer;
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
            spawner.GetComponent<SpawnerCode>().initAngle = -(rotationSpeed*timer)%360;
            spawner.GetComponent<SpawnerCode>().fire(-1f, true);
        }


    }
}
