using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockedAngleBullet : MonoBehaviour
{
    public float speed;
    public Vector2 spawnPoint;
    private Vector3 movement;
    public float angle;
    public float facing = 0f;
    public float test;
    public float maxH = 20f;
    public float maxV = 11.5f;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = new Vector2(transform.position.x, transform.position.y);
        movement = new Vector3(Mathf.Sin(Mathf.Deg2Rad * angle), Mathf.Cos(Mathf.Deg2Rad * angle));
        gameObject.transform.eulerAngles = new Vector3(0, 0, facing);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (movement* speed * Time.deltaTime);
        if(transform.position.x <= -maxH || transform.position.x >= maxH || transform.position.y <= -maxV || transform.position.y >= maxV)
        {
            Destroy(this.gameObject);
        }
    }
    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Boundary" || collision.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }*/
}
