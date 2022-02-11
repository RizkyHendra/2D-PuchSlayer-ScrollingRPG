﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    float dirX, moveSpeed;
    bool Hurt, Death;
    bool facingRight = true;
    Vector3 localScale;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        localScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && !Death && rb.velocity.y == 0)
        {
            rb.AddForce(Vector2.up * 600f);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 5f;
        }
        else
        {
            moveSpeed = 5f;
        }
        SetAnimationState();
        if (!Death)
        {
            dirX = Input.GetAxisRaw("Horizontal") * moveSpeed;
        }


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
        if (dirX == 0)
        {
            anim.SetBool("Run", false);
        }
        if (rb.velocity.y == 0)
        {
            anim.SetBool("Jump", false);
            anim.SetBool("Fall", false);
        }
        if (Mathf.Abs(dirX) == 5 && rb.velocity.y == 0)
        {
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }
       
        if (Input.GetKey(KeyCode.DownArrow) && Mathf.Abs(dirX) == 5)
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


    IEnumerator isHurt()
    {
        Hurt = true;
        rb.velocity = Vector2.zero;
        if (facingRight)
            rb.AddForce(new Vector2(-200f, 200f));
        else
            rb.AddForce(new Vector2(200f, 200f));
        yield return new WaitForSeconds(0.5f);
        Hurt = false;
    }
}