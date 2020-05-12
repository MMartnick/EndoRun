using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{

    public string restartLevel;
    public string mainMenu;


    public GameObject DeathScreen;
    public bool deathScreenActive = false;
    public static bool deathScreenNotifier;

    public void StartGame()
    {
        SceneManager.LoadScene(restartLevel);
        Hide();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }

    public void Hide()
    {
        Destroy(DeathScreen);
        Time.timeScale = 1;
    }

    public void Show()
    {
        deathScreenActive = true;
        deathScreenNotifier = true;
        Time.timeScale = 0;
    }

    public void Update()
    {
        if(deathScreenActive == true)
        {
            Instantiate(DeathScreen, transform.position, transform.rotation);
            deathScreenActive = false;
        }
    }
}
