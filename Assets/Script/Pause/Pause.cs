using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    bool isPuase = false;
    bool Unpause = true;

    

    public void Start()
    {
       
    }

    public void Update()
    {
        
       
    }
    public void pauseGame()
    {
        if(Unpause)
        {
            Time.timeScale = 1;
            isPuase = false;
        }
        else
        {
            Time.timeScale = 0;
            Unpause = true;
        }
    }

    public void pauseGame1()
    {
        if (isPuase)
        {
            Time.timeScale = 1;
            isPuase = false;
        }
        else
        {
            Time.timeScale = 0;
            isPuase = true;
        }
    }




}
