using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private Vector3 Position;
    private double x;
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   private double y;
    private  double plusx_z;
    private double z;
    private double speedx;
    private double speedz;
    private float fspx;
    private float fspz;
    // Start is called before the first frame update
    void Start()
    {
        Position = transform.position;
        x = Position.x;
        z = Position.z;
        plusx_z = Math.Pow(x,2) + Math.Pow(z,2); 
        y = Math.Sqrt(plusx_z);
        speedx = -x % y;
        speedz = -z % y;
        fspx = (float)speedx;
        fspz = (float)speedz;


    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position += new Vector3(fspx*0.1f, 0, fspz*0.1f) * Time.deltaTime;
    }
    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "bullet"){
              Destroy(gameObject);
        }

    }
}
