using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator anim;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;
    public int attackDamage = 40;
    private Rigidbody2D rb;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetKey(KeyCode.R) && rb.velocity.y == 0)
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
       
    }

    void Attack()
    {
        anim.SetTrigger("Attack");
        Collider2D [] hitEnemy = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach(Collider2D enemy in hitEnemy)
        {
            enemy.GetComponent<EnemyAction>().TakeDamage(attackDamage);
        }
    }

     void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }
       
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}

