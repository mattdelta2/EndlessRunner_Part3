using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void MainMenuLoad()
    {
        SceneManager.LoadScene("MainMenu");

    }

    public void Quit()
    {
        Application.Quit();
    }
}

