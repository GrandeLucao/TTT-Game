using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 movement;
    public float health;
    public int level=1;
    public float speed;
    private bool isFire;
    public bool isDead;
    public Animator anima; 
    public Animator animLeg;

    private Rigidbody2D rig;

    void Start()
    {
        rig=GetComponent<Rigidbody2D>();
        isDead=false;
    }

    void Update()
    {
        movement.x=Input.GetAxisRaw("Horizontal");
        movement.y=Input.GetAxisRaw("Vertical");
        animLeg.SetFloat("Horizontal", movement.x);
        animLeg.SetFloat("Vertical", movement.y);
    }
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if(!isDead)
        {
            rig.MovePosition(rig.position+movement*speed*Time.fixedDeltaTime);
        }
    }

    public void Damage(int dmg)
    {
        health-=dmg;
        if(health<=0)
        {           
            anima.SetTrigger("dead"); 
            isDead=true;
            FindObjectOfType<PlayerMouse>().playaDead=true;
            GameController.instance.GameOver();
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag=="EndGame")
        {
            GameController.instance.EndGame();
        }

        if(coll.gameObject.tag=="medkit")
        {
            health+=2;
            FindObjectOfType<legDestroy>().isDead=true;
            GameController.instance.StartCoroutine("healthUp");
        }

        if(coll.gameObject.tag=="medkit2")
        {
            health+=2;
            FindObjectOfType<medkitDestroy>().isDead=true;
            GameController.instance.StartCoroutine("healthUp");
        }
    }


}
