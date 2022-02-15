using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator anim;
    public GameObject SkillOne;
    public Transform attackPoint;
    public Transform skillPoint;
    public float attackRange = 0.5f;
    public float SkillRange = 0.5f;
    public LayerMask enemyLayer;
    public int attackDamage = 20;
    public int skillDamage = 40;
    private Rigidbody2D rb;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    public int combo = 0;

    public EnemyAction _comboTree;
    

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
                Skill1();
                nextAttackTime = Time.time + 1f / attackRate;
                StartCoroutine("skillOneActive");
                

            }
            if (Input.GetMouseButtonDown(0) && rb.velocity.y == 0)
            {
                combo++;
               
                if (combo == 1)

                {
                    Attack1();
                    nextAttackTime = Time.time + 1f / attackRate;

                    
                }
                if (combo == 2)
                {
                    Attack2();
                    nextAttackTime = Time.time + 1f / attackRate;
                }
                if (combo == 3)
                {
                    Attack3();
                   
                    nextAttackTime = Time.time + 1f / attackRate;
                  
                    combo = 0;
                   
                }

                combo = Mathf.Clamp(combo, 0, 3);

            }
            if (Input.GetMouseButtonDown(0) && rb.velocity.y > 0)
            {
                AttackJump();
                nextAttackTime = Time.time + 1f / attackRate;
            }

        }
       
       
       
      



    }

   
    void Attack1()
    {
        anim.SetTrigger("Attack");
        Collider2D [] hitEnemy = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
    
        foreach(Collider2D enemy in hitEnemy)
        {
            enemy.GetComponent<EnemyAction>().TakeDamage(attackDamage);

        }
      
        
    }
    void Attack2()
    {
        anim.SetTrigger("Attack2");
        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemy)
        {
            enemy.GetComponent<EnemyAction>().TakeDamage(attackDamage);
        }
    }
   public void Attack3()
    {
       
        anim.SetTrigger("Attack3");
        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemy)
        {
            enemy.GetComponent<EnemyAction>().TakeDamage(attackDamage);
        }
    }

    void AttackJump()
    {
        anim.SetTrigger("JumpAttack");
        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemy)
        {
            enemy.GetComponent<EnemyAction>().TakeDamage(attackDamage);
        }
    }
   

    void Skill1()
    {

        anim.SetTrigger("Skill1");
        
        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(skillPoint.position, SkillRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemy)
        {
            enemy.GetComponent<EnemyAction>().TakeDamage(skillDamage);
        }
        
    }

    public IEnumerator skillOneActive()
    {
        SkillOne.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        SkillOne.SetActive(false);
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        if(skillPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        Gizmos.DrawWireSphere(skillPoint.position, SkillRange);
    }

}

