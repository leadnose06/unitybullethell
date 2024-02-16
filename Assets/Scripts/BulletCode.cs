using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCode : MonoBehaviour
{
    public float speed;
    private Vector2 spawnPoint;
    private Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = new Vector2(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Boundary" || collision.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }
}
