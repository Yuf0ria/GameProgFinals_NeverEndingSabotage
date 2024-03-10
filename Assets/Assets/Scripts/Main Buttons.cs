using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainButtons : MonoBehaviour
{
    [Header("Other Scripts")]
    public GameObject buttonResume;
    public GameObject buttonBackMain;
    public GameObject buttonQuit;
    public GameObject buttonPause;

    private bool isPaused = false;

    public void Start()
    {
        buttonResume.SetActive(false);
        buttonBackMain.SetActive(false);
        buttonQuit.SetActive(false);

        buttonPause.SetActive(true);
    }

    // The Game Pause
    public void TogglePause()
    {
        isPaused = !isPaused;

        Time.timeScale = isPaused ? 0 : 1;

        buttonResume.SetActive(true);
        buttonBackMain.SetActive(true);
        buttonQuit.SetActive(true);

        buttonPause.SetActive(false);
    }

    // Unpause the game
    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1;

        buttonResume.SetActive(false);
        buttonBackMain.SetActive(false);
        buttonQuit.SetActive(false);

        buttonPause.SetActive(true);
    }

    //Quit Button
    public void Quit_Application_1()
    {
        Application.Quit();
    }

    public void BackToMainMenu()
    {
        isPaused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("Starting Screen");
    }
}
