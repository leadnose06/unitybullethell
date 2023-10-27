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

    [Header("Bullet Attributes")]
    public GameObject bullet;
    public float speed;

    [Header("Spawner Attributes")]
    [SerializeField] private SpawnerType spawnerType;
    [SerializeField] private float firingRate;
    [SerializeField] private float initAngle;
    [SerializeField] private float rotationSpeed;
    


    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, initAngle);
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
                Quaternion rotation = Quaternion.LookRotation(target.transform.position - transform.position, transform.TransformDirection(Vector3.forward));
                transform.rotation = new Quaternion(0f, 0f, rotation.z, rotation.w);
            }
            if(timer >= firingRate)
            {
                fire();
                timer = 0f;
            }
        }
    }

    private void fire()
    {
        if (bullet)
        {
            SpawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            SpawnedBullet.GetComponent<BulletCode>().speed = speed;
            SpawnedBullet.transform.rotation = transform.rotation;
        }
    }
}
