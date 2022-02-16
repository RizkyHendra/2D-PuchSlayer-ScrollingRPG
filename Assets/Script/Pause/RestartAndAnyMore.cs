using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartAndAnyMore : MonoBehaviour
{
   public void RestartGame()
    {
        SceneManager.LoadScene("Story_1");
        Time.timeScale = 1;
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("Lobby");
        Time.timeScale = 1;
    }

    public void Stage2()
    {
        SceneManager.LoadScene("Story_2");
    }
    public void Stage1()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Story_1");
    }
}
