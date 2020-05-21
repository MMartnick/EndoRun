using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string level;
    public string credits;
    public string main;

    public void StartGame()
    {
        SceneManager.LoadScene(level);
    }

    public void Credits()
    {
        SceneManager.LoadScene(credits);
    }

    public void Main()
    {
        SceneManager.LoadScene(main);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
