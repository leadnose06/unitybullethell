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
            /*Vector3 targetPosition = turret.transform.position - target.transform.position;
            float targetRotation = Mathf.Atan(targetPosition.y / targetPosition.x);
            turret.transform.eulerAngles = new Vector3(0f,0f,targetRotation);
            turret.transform.rotation = Quaternion.Slerp(Quaternion.Euler(target.transform.position.x, -90f, 0f), Quaternion.LookRotation(target.transform.position), 2f * Time.deltaTime);*/



        }
    }
}
