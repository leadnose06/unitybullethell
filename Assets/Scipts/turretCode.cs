using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretCode : MonoBehaviour
{
    public bool on = false;
    public bool shooting = false;
    public GameObject turret;
    Collider myCollider;

    // Start is called before the first frame update
    void Start()
    {
        myCollider = turret.GetComponent<Collider>();
        if (!on)
        {
            turret.GetComponent<Renderer>().enabled = false;
            myCollider.enabled = false;
        }
    }

    public void turnOn()
    {
        turret.GetComponent<Renderer>().enabled = true;
        myCollider.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
