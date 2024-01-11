using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockedAngleBullet : MonoBehaviour
{
    public float speed;
    private Vector2 spawnPoint;
    private Vector3 movement;
    public float angle;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = new Vector2(transform.position.x, transform.position.y);
        movement = new Vector3(Mathf.Sin(Mathf.Deg2Rad * angle), Mathf.Cos(Mathf.Deg2Rad * angle));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += movement* speed * Time.deltaTime;
    }
}
