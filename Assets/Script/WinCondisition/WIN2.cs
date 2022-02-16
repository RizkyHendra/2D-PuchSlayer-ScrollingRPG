using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WIN2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject WIN22;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Character")
        {
            WIN22.SetActive(true);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Character")
        {
            WIN22.SetActive(false);
        }
    }
}
