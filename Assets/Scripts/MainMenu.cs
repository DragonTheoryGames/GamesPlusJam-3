using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void playGame()
    {
        SceneManager.LoadScene("test_Mansion");
    }

    public void loadCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void toMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
