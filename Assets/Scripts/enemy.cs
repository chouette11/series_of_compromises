using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using WebSocketSharp;

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
    private double plusx_z;
    private double z;
    private double speedx;
    private double speedz;
    private float fspx;
    private float fspz;
    private float span = 0;
    private bool on_off = true;
    private GameObject tower;
    private int enemyHP;
    private float distancespan;
    private towescript towerscript;
    private float AttackSpan;
    private WebSocketClient webSocketClient;

    private string id;





    // Start is called before the first frame update
    void Start()
    {
        tower = GameObject.Find("tower");
        enemyHP = 3;
        span = 0;
        Anim = this.GetComponent<Animator>();
        Ctrl = this.GetComponent<CharacterController>();
        webSocketClient = GameObject.Find("WebsocketFloor").GetComponent<WebSocketClient>();
        id = gameObject.GetComponent<AssignedId>().id;
    }

    void Distance()
    {
        Position = transform.position;
        x = Position.x - tower.transform.position.x;
        z = Position.z - tower.transform.position.z;
        plusx_z = Math.Pow(x, 2) + Math.Pow(z, 2);
        y = Math.Sqrt(plusx_z);
        speedx = -x % y;
        speedz = -z % y;
        fspx = (float)speedx;
        fspz = (float)speedz;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(tower.transform);
        distancespan += Time.deltaTime;
        transform.position += new Vector3(fspx * 0.5f, 0, fspz * 0.5f) * Time.deltaTime;
        if (enemyHP <= 0)
        {
            Position = transform.position;
            SendPositionData sendPositionData = new SendPositionData(Position.x, Position.y, Position.z, id, "enemy", false, "unity");
            webSocketClient.SendMessageToServer(sendPositionData);
            Destroy(gameObject);

        }
        if (distancespan >= 0.01f)
        {
            Vector3 position = transform.position;
            SendPositionData sendPositionData = new SendPositionData(position.x / 16, position.y, position.z / 20, id, "enemy", true, "unity");
            webSocketClient.SendMessageToServer(sendPositionData);
            Distance();
            distancespan = 0;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            Anim.CrossFade(DissolveState, 0.1f, 0, 0);
            enemyHP = enemyHP - 1;
        }
         if(collision.gameObject.tag == "katana"){
      enemyHP = enemyHP - 4;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "tower")
        {
            AttackSpan += Time.deltaTime;
            if (AttackSpan >= 1f)
            {
                Attack();
            }
        }

    }

    void Attack()
    {
        towerscript = tower.GetComponent<towescript>();
        towerscript.Hpmanage = false;
        AttackSpan = 0;
    }}

