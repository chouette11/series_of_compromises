using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemy : MonoBehaviour
{
        private Animator Anim;
    private CharacterController Ctrl;
    private Vector3 MoveDirection = Vector3.zero;
        private static readonly int IdleState = Animator.StringToHash("Base Layer.idle");
     private static readonly int MoveState = Animator.StringToHash("Base Layer.move");
     private static readonly int SurprisedState = Animator.StringToHash("Base Layer.surprised");
     private static readonly int AttackState = Animator.StringToHash("Base Layer.attack_shift");
     private static readonly int DissolveState = Animator.StringToHash("Base Layer.dissolve");
     private static readonly int AttackTag = Animator.StringToHash("Attack");
    private Vector3 Position;
    private double x;
    private double y;
    private  double plusx_z;
    private double z;
    private double speedx;
    private double speedz;
    private float fspx;
    private float fspz;
    private float span =0;
    // Start is called before the first frame update
    void Start()
    {
        
        Anim = this.GetComponent<Animator>();
        Ctrl = this.GetComponent<CharacterController>();
        Position = transform.position;
        x = Position.x -8;
        z = Position.z -10;
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
             Anim.CrossFade( DissolveState , 0.1f, 0, 0);
          
                Destroy(gameObject);
             
              
        }

    }
    void Attack (){

    }
}
