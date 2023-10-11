using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraBounds : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0, 0, -10);
    bool cameraFollow = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Boundary")
        {
            cameraFollow = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Boundary")
        {
            cameraFollow = true;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (cameraFollow)
        {
            transform.position = player.transform.position + offset;
        }
    }
}
