using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCode : MonoBehaviour
{
    enum SpawnerType { Straight, Target, Spin, Circle}


    public bool on;
    private float timer = 0f;
    private GameObject SpawnedBullet;
    public GameObject target;
    private Vector3 dir;
    private float adjFireRate;
    private float fullTimer;

    [Header("Bullet Attributes")]
    public GameObject bullet;
    public float speed = 1000f;
    public bool lockedAngle;

    [Header("Spawner Attributes")]
    [SerializeField] private SpawnerType spawnerType;
    [SerializeField] private float firingRate;
    [SerializeField] public float initAngle;
    [SerializeField] private float rotationSpeed;
    [SerializeField] public GameObject attached;
    [SerializeField] public float offsetX = 0;
    [SerializeField] public float offsetY = 0;
    [SerializeField] private float maxDelay;
    [SerializeField] private float circleBullets;
    [SerializeField] private float initDelay;
    [SerializeField] private bool triggered = false;




    // Start is called before the first frame update
    void Start()
    {
        adjFireRate = firingRate + initDelay + Random.value * maxDelay*3;
        fullTimer = initAngle / 360f;
        //transform.rotation = Quaternion.Euler(0f, 0f, initAngle);
        if (attached)
        {
            transform.position = attached.transform.position;
        }
    }

    public void turnOnOrOff()
    {
        if (!on)
        {
            on = true;
        }
        else
        {
            on = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (on)
        {
            timer += Time.deltaTime;
            fullTimer += Time.deltaTime/(rotationSpeed+0.01f);
            if (fullTimer >= 1)
            {
                fullTimer = 0;
            }
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
            if(timer >= adjFireRate &! triggered)
            {
                fire();
                timer = 0f;
                adjFireRate = firingRate + Random.value * maxDelay;
            }
        }
        if (attached)
        {
            transform.position = attached.transform.position+new Vector3(offsetX, offsetY);
        }
    }

    public void fire(float spd = -1f, bool face = false)
    {
        if(spd == -1f)
        {
            spd = speed;
        }
        if (bullet)
        {
            if (lockedAngle && spawnerType == SpawnerType.Straight)
            {
                SpawnedBullet = ObjectPool.SharedInstance.GetPooledObject();
                if(SpawnedBullet != null)
                {
                    SpawnedBullet.transform.position = transform.position;
                    SpawnedBullet.transform.rotation = Quaternion.identity;
                    SpawnedBullet.GetComponent<lockedAngleBullet>().speed = spd / -100;
                    SpawnedBullet.GetComponent<lockedAngleBullet>().angle = initAngle;
                    if (face)
                    {
                        SpawnedBullet.GetComponent<lockedAngleBullet>().facing = initAngle;
                    }
                    SpawnedBullet.SetActive(true);
                }
            }
            else if (lockedAngle && spawnerType == SpawnerType.Spin)
            {
                SpawnedBullet = ObjectPool.SharedInstance.GetPooledObject();
                if(SpawnedBullet != null)
                {
                    SpawnedBullet.transform.position = transform.position;
                    SpawnedBullet.transform.rotation = Quaternion.identity;
                    SpawnedBullet.GetComponent<lockedAngleBullet>().speed = spd / -100;
                    SpawnedBullet.GetComponent<lockedAngleBullet>().angle = (360 * fullTimer);
                    if (face)
                    {
                        SpawnedBullet.GetComponent<lockedAngleBullet>().facing = (360 * fullTimer);
                    }
                    SpawnedBullet.SetActive(true);
                }
            }
            else if (lockedAngle && spawnerType == SpawnerType.Target)
            {
                SpawnedBullet = ObjectPool.SharedInstance.GetPooledObject();
                if(SpawnedBullet != null)
                {
                    SpawnedBullet.transform.position = transform.position;
                    SpawnedBullet.transform.rotation = Quaternion.identity;
                    SpawnedBullet.GetComponent<lockedAngleBullet>().speed = spd / -100;
                    SpawnedBullet.GetComponent<lockedAngleBullet>().angle = attached.GetComponent<boss1Code>().bossTargetAngle;
                    if (face)
                    {
                        SpawnedBullet.GetComponent<lockedAngleBullet>().facing = attached.GetComponent<boss1Code>().bossTargetAngle;
                    }
                    SpawnedBullet.SetActive(true);
                }
            }
            else if (lockedAngle && spawnerType == SpawnerType.Circle)
            {
                for(int i=0; i<circleBullets; i++) 
                {
                    SpawnedBullet = ObjectPool.SharedInstance.GetPooledObject();
                    if(SpawnedBullet != null)
                    {
                        SpawnedBullet.transform.position = transform.position;
                        SpawnedBullet.transform.rotation = Quaternion.identity;
                        SpawnedBullet.GetComponent<lockedAngleBullet>().speed = spd / -100;
                        SpawnedBullet.GetComponent<lockedAngleBullet>().angle = initAngle+(360/circleBullets)*i;
                        if (face)
                        {
                            SpawnedBullet.GetComponent<lockedAngleBullet>().facing = -initAngle;
                        }
                        SpawnedBullet.SetActive(true);
                    }
                }
            }
            else
            {
                SpawnedBullet = ObjectPool.SharedInstance.GetPooledObject();
                if(SpawnedBullet != null)
                {
                    SpawnedBullet.transform.position = transform.position;
                    SpawnedBullet.transform.rotation = Quaternion.identity;
                    SpawnedBullet.GetComponent<BulletCode>().speed = spd / -100;
                    SpawnedBullet.transform.rotation = transform.rotation;
                    SpawnedBullet.SetActive(true);
                }
            }
            if(SpawnedBullet == null){
                Debug.Log("increase");
            }
        }
    }
}
