using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    [SerializeField] GameObject Chest, key, info;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {
            

            key.SetActive(true);
            anim.SetBool("Open", true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
     

        if (collision.gameObject.tag == "Character" )
        {
            info.SetActive(true);
   

        }
       

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Character")
        {
            info.SetActive(false);


        }
    }


}
