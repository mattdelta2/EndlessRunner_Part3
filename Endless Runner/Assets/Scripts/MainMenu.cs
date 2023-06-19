using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  public void gamePlay()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }


    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void HighScore()
    {
        SceneManager.LoadScene("HighScore");
    }

}
