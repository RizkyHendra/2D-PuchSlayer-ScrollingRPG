using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeCoin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Character")
        {
            SoundManager.Playsound("Coin");

            CoinCounter.cointAmount += 1;
            Destroy(gameObject);

        }
    }
}
