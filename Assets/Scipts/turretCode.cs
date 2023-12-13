using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretCode : MonoBehaviour
{
    public bool on = false;
    public bool shooting = false;
    public GameObject turret;
    Collider myCollider;
    public GameObject target;

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
        on = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (on)
        {
            Vector3 dir = target.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle+90, Vector3.forward);



        }
    }
}
