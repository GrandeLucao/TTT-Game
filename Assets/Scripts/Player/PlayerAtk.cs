using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtk : MonoBehaviour
{
    public Animator anim;
    public Transform atkPoint;
    public float atkRange=0.5f;
    public int damage;
    public LayerMask enemyLayers;
    public bool isAtacking;


    void Update()
    {
        Attack();
        
    }

    void Attack()
    {
        StartCoroutine("Fire");


    }

    IEnumerator Fire()
    {
        if(Input.GetButtonDown("Fire1") && !isAtacking)
        {
            isAtacking=true;
            FindObjectOfType<AudioMtFoda>().Play("hammer");
            anim.SetInteger("transition", 1);
        Collider2D[] hitEnemies=Physics2D.OverlapCircleAll(atkPoint.position, atkRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Inimigo>().Damage(damage);
        }
            yield return new WaitForSeconds(0.7f);
            anim.SetInteger("transition", 0);
            isAtacking=false;

        }
    }
}
