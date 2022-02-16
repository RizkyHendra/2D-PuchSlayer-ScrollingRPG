using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartAndAnyMore : MonoBehaviour
{
   public void RestartGame()
    {
        SceneManager.LoadScene("Lvl1");
        Time.timeScale = 1;
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void Stage2()
    {
        SceneManager.LoadScene("Lvl2");
    }
}
