using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour
{
    public GameObject menupanel;
    public GameObject creditpanel;

    public void PlayButton()
    {
        SceneManager.LoadScene("Game");
        Debug.Log("Created by Aditya");
    }

    public void Credit()
    {
        // SceneManager.LoadScene("Credit");
        menupanel.SetActive(false);
        creditpanel.SetActive(true);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void back()
    {
        menupanel.SetActive(true);
        creditpanel.SetActive(false);
    }
}
