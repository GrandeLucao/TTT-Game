using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public float speed;
    public int health;
    public int damage;

    public LayerMask Player;
    private Transform target;
    private Rigidbody2D rb;
    private Animator anim;

    private Vector2 movement;
    public Vector3 dir;

    public float attackRadius;

    public bool active;
    private bool isInAttackRange;

    private bool playaDead;

    void Start()
    {
        playaDead=FindObjectOfType<PlayerMouse>().playaDead;
        rb=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;     
    }

    // Update is called once per frame
    void Update()
    {

        isInAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, Player);
        if(active){
            dir = target.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            rb.rotation=angle;
            dir.Normalize();
            movement = dir;
        }
        checkDeath();
    }

    private void FixedUpdate(){
        if(active && !playaDead){
            MoveCharacter(movement);
        }
        if(isInAttackRange){
            rb.velocity = Vector2.zero;
        }
    }


    public void Damage(int dmg)
    {
        health-=dmg;
    }

    public void checkDeath(){                
        if(health<=0)
        {
            active=false;
            anim.SetTrigger("dead");
        }
    }

    private void MoveCharacter(Vector2 dir){
        rb.MovePosition((Vector2)transform.position + (dir * speed * Time.deltaTime));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player" && active)
        {
            anim.SetInteger("transtion",1);
            collision.gameObject.GetComponent<Player>().Damage(damage); 
        }
    }
}
