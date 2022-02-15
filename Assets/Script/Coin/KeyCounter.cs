using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyCounter : MonoBehaviour
{
    Text keyText;
    public static int keyAmount;
    void Start()
    {
        keyText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        keyText.text = keyAmount.ToString();
    }
}
