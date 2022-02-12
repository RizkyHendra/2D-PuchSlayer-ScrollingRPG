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

    private void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
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

    void Die()
    {
       
        Debug.Log("EnemyDie");
        anim.SetBool("Death", true);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
