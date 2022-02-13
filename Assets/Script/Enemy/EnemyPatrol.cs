using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float runSpeed;
    [HideInInspector]
    public bool mustPatrol;
    public Rigidbody2D rb;
    public Transform groundCheckPos;
    private bool mustTurn;
    public LayerMask groundLayer;

    public Animator anim;
    

    public Collider2D bodyCollider;
    void Start()
    {
        mustPatrol = true;
    }

    

    // Update is called once per frame
    void Update()
    {
        if(mustPatrol)
        {
            Patrol();
        }
    }
    
   private void FixedUpdate()
    { 
        if(mustPatrol)
        {
            mustTurn = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
        }
    }

    void Patrol()
    {
        if (mustTurn || bodyCollider.IsTouchingLayers(groundLayer))
        {
            flip();
        }
        rb.velocity = new Vector2(runSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    void flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        runSpeed *= -1;
        mustPatrol = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Character")
        {
            anim.SetBool("Attack", true);
        }
    }

}
