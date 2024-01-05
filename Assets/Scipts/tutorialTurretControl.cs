using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialTurretControl : MonoBehaviour
{
    public float duration;
    private float timer;
    public GameObject turret;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= duration)
        {

        }
    }
}
