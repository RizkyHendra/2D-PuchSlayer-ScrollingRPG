using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveCharacter : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    float dirX, moveSpeed;
    bool Hurt, Death;
    bool facingRight = true;
    Vector3 localScale;

    // health

    
    public int maxHealth;
    public int currentHealth;
    public HealthBar healthbar;
   


    // Start is called before the first frame update
    void Start()
    {
       
       
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        localScale = transform.localScale;
        currentHealth = maxHealth;
        healthbar.setMaxhealth(maxHealth);
       
      
    }

    // Update is called once per frame
    void Update()
    {
        
       
        
        if (Input.GetButtonDown("Jump") && !Death && rb.velocity.y == 0)
        {
            rb.AddForce(Vector2.up * 450f);
        }
      
        SetAnimationState();
        if (!Death)
        {
            moveSpeed = 2.5f;
            dirX = Input.GetAxisRaw("Horizontal") * moveSpeed;
        }


    }
    void takeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.setHealth(currentHealth); 
    }
    private void FixedUpdate()
    {
        if (!Hurt)
        {
            rb.velocity = new Vector2(dirX, rb.velocity.y);
        }
    }
    private void LateUpdate()
    {
        CheckWhereToFace();
    }

    void SetAnimationState()
    {
        if (currentHealth < 0)
        {
            currentHealth = 0;
            anim.SetTrigger("Death");

            Death = true;

            dirX = 0;
        }

        if (dirX == 0)
        {
           
            anim.SetBool("Run", false);
        }
        if (rb.velocity.y == 0)
        {
            anim.SetBool("Jump", false);
            anim.SetBool("Fall", false);
        }
        if (Mathf.Abs(dirX) == 2.5 && rb.velocity.y == 0)
        {
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }
       
        if (Input.GetKey(KeyCode.DownArrow) && Mathf.Abs(dirX) == 2)
        {
            anim.SetBool("Dash", true);
        }
        else
        {
            anim.SetBool("Dash", false);
        }
        if( rb.velocity.y > 0)
        {
            anim.SetBool("Jump", true);
        }
       
        if (rb.velocity.y < 0)
        {
            anim.SetBool("Jump", false);
            anim.SetBool("Fall", true);
        }
    }
    void CheckWhereToFace()
    {
        if (dirX > 0)
            facingRight = true;
        else if (dirX < 0)
            facingRight = false;
        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1;
        transform.localScale = localScale;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.tag =="Star")
        {
            StartCoroutine("isHurt");
            anim.SetTrigger("Hurt");
           
            takeDamage(1);

        }

        if (currentHealth == 0)
        {
            anim.SetTrigger("Death");
           
            Death = true;

            dirX = 0;
        }

        if (collision.gameObject.tag == "Spike")
        {
            
            anim.SetTrigger("Hurt");
           
            takeDamage(10);

        }

        if (collision.gameObject.tag == "Water")
        {
            takeDamage(100);
            anim.SetTrigger("Death");

            Death = true;

            dirX = 0;

           

        }





    }

    

    IEnumerator isHurt()
    {
        Hurt = true;
        rb.velocity = Vector2.zero;
        if (facingRight)
            rb.AddForce(new Vector2(-100f, 100f));
        else
            rb.AddForce(new Vector2(150f, 150f));
        yield return new WaitForSeconds(0.5f);
        Hurt = false;


        
    }
}
