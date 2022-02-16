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
    public GameObject Pause;

    // health
    public int maxHealth;
    public int currentHealth;
    public HealthBar healthbar;

    // stamina
    public float maxStamina;
    public float currentStamina;
    public StaminaBar staminaBar;

  


    // Start is called before the first frame update
    void Start()
    {
       
       
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        localScale = transform.localScale;
        currentHealth = maxHealth;
        healthbar.setMaxhealth(maxHealth);

        currentStamina = maxStamina;
        staminaBar.setMaxStamina(maxStamina);
       
      
    }
    

    // Update is called once per frame
    void Update()
    {
       
        if (currentHealth > 100)
        {
            currentHealth = 100;
        }
        if (currentStamina > 100)
        {
            currentStamina = 100;
        }
        if (Input.GetButtonDown("Jump") && !Death && rb.velocity.y == 0)
        {
            SoundManager.Playsound("Jump");
            rb.AddForce(Vector2.up * 450f);
        }
      
        SetAnimationState();
        if (!Death)
        {
            moveSpeed = 2.5f;
            dirX = Input.GetAxisRaw("Horizontal") * moveSpeed;
        }

      
    }

    void Stamina(float stamina)
    {
        currentStamina -= stamina;
        staminaBar.setStamina(currentStamina);
    }

    
    void takeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.setHealth(currentHealth); 
    }

    void HealthPotion(int Health)
    {
        currentHealth += Health;
        healthbar.setHealth(currentHealth);
    }

    void StaminaPotion(float staminaPlus)
    {
        currentStamina += staminaPlus;
        staminaBar.setStamina(currentStamina);
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


        if (Input.GetKey(KeyCode.Q) && Mathf.Abs(dirX) == 2.5 &&  currentStamina > 0 && rb.velocity.y == 0)
        {
            if(facingRight == true)
            {
                
                anim.SetBool("Dash", true);
                Stamina(0.1f);
                rb.AddForce(Vector2.right * 75f);
            }    

            if(facingRight == false)
            {
                
                anim.SetBool("Dash", true);
                Stamina(0.1f);
                rb.AddForce(Vector2.left * 75f);
            }
           

        }
        else
        {
            anim.SetBool("Dash", false);
            rb.AddForce(Vector2.right * 0f);
            rb.AddForce(Vector2.left * 0f);
        }
    
       
    







        if (rb.velocity.y > 0)
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
            SoundManager.Playsound("Hurt");

            takeDamage(1);

        }

        if (currentHealth == 0)
        {
            SoundManager.Playsound("Hurt");
            anim.SetTrigger("Death");
           
            Death = true;
            Pause.SetActive(true);
            dirX = 0;
        }

        if (collision.gameObject.tag == "Spike")
        {
            
            anim.SetTrigger("Hurt");
           
            takeDamage(10);
            SoundManager.Playsound("Hurt");

        }

        if (collision.gameObject.tag == "Water")
        {
            takeDamage(100);
            anim.SetTrigger("Death");
            Pause.SetActive(true);
          
            Death = true;

            dirX = 0;

           

        }
        if (collision.gameObject.tag == "PotionRed")
        {
            HealthPotion(10);
            SoundManager.Playsound("Potion");



        }
        if (collision.gameObject.tag == "PotionBlue")
        {
            StaminaPotion(10f);
            SoundManager.Playsound("Potion");





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
