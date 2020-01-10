using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{

    public string restartLevel;
    public string mainMenu;


    public GameObject DeathScreen;
    public bool deathScreenActive;

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
    }

    public void Show()
    {
        deathScreenActive = true;
    }

    public void Update()
    {
        if(deathScreenActive)
        {
            Instantiate(DeathScreen, transform.position, transform.rotation);
            deathScreenActive = false;
        }
    }
}
