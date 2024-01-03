using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCode : MonoBehaviour
{
    enum SpawnerType { Straight, Target, Spin}


    public bool on;
    private float timer = 0f;
    private GameObject SpawnedBullet;
    public GameObject target;
    private Vector3 dir;
    private float adjFireRate;

    [Header("Bullet Attributes")]
    public GameObject bullet;
    public float speed;

    [Header("Spawner Attributes")]
    [SerializeField] private SpawnerType spawnerType;
    [SerializeField] private float firingRate;
    [SerializeField] private float initAngle;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private GameObject attached;
    [SerializeField] private float maxDelay;




    // Start is called before the first frame update
    void Start()
    {
        adjFireRate = firingRate + Random.value * maxDelay*3;
        //transform.rotation = Quaternion.Euler(0f, 0f, initAngle);
        if (attached)
        {
            transform.position = attached.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (on)
        {
            timer += Time.deltaTime;
            if(spawnerType == SpawnerType.Spin)
            {
                transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + rotationSpeed);
            }else if(spawnerType == SpawnerType.Target)
            {
                dir = target.transform.position - transform.position;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
                //Quaternion rotation = Quaternion.LookRotation(target.transform.position - transform.position, transform.TransformDirection(Vector3.forward));
                //transform.rotation = new Quaternion(0f, 0f, rotation.z, rotation.w);
            }
            if(timer >= adjFireRate)
            {
                fire();
                timer = 0f;
                adjFireRate = firingRate + Random.value * maxDelay;
            }
        }
        if (attached)
        {
            transform.position = attached.transform.position;
        }
    }

    private void fire()
    {
        if (bullet)
        {
            SpawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            SpawnedBullet.GetComponent<BulletCode>().speed = speed/-100;
            SpawnedBullet.transform.rotation = transform.rotation;
            SpawnedBullet.SetActive(true);
        }
    }
}
