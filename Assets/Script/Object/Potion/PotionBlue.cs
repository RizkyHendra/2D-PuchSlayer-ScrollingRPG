using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionBlue : MonoBehaviour
{
    public GameObject game;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Character")
        {
            game.SetActive(false);




        }

    }
}
