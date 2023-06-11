using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
    }
   
    public void ShowScreen()
    {
        gameObject.SetActive(true);
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MainMenuLoad()
    {
        SceneManager.LoadScene("MainMenu");

    }
}

