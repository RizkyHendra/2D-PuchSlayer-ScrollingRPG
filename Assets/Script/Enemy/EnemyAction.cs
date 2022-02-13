using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAction : MonoBehaviour
{
    //public int health;
    //public float speed;
    //private Animator anim;
    //public GameObject bloodEffect;
    //void Start()
    //{
    //    anim = GetComponent<Animator>();
    //    anim.SetBool("Run", true);
    //}

    //Update is called once per frame
    //void Update()
    //{
    //    if (health <= 0)
    //    {
    //        anim.SetBool("Death", true);
    //        anim.SetBool("Run", false);

    //        speed = 0;

    //        Destroy(gameObject);
    //    }
    //    transform.Translate(Vector2.left * speed * Time.deltaTime);
    //}
    //public void TakeDamage(int damage)
    //{
    //    Instantiate(bloodEffect, transform.position, Quaternion.identity);
    //    health -= damage;
    //    Debug.Log("Damage Taken !!!");


    //}
    public Animator anim;
    public int maxHealth = 100;
    int currentHealth;
    public float speed;
    public GameObject enemy;
    public PlayerAttack _combo;
    Vector3 localScale;

    Rigidbody2D rb;
    private void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        anim.SetBool("Run", true);
        rb = GetComponent<Rigidbody2D>();
        localScale = transform.localScale;


    }

    public void TakeAir()
    {
        
            //rb.AddForce(Vector2.up * 200f);
        
       
    }

   
    public void TakeDamage(int damage)
    {
        
        
        currentHealth -= damage;
        
        anim.SetTrigger("Hurt" );
        if(currentHealth <= 0)
        {
            Die();
        }
    }
    private void Update()
    {
       
       
       
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            speed *= -1;
        }

        if (collision.gameObject.tag == "Character")
        {
            anim.SetBool("Attack", true);
        }
        else
        {
            anim.SetBool("Attack", false);
        }


    }

    void Die()
    {
       
        Debug.Log("EnemyDie");
        StartCoroutine("enemyDie");
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }

    public IEnumerator enemyDie()
    {
        anim.SetBool("Death", true);
        yield return new WaitForSeconds(1.5f);
        enemy.SetActive(false);
    }
}
