using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainButtons : MonoBehaviour
{
    /// <summary>
    /// The Main UI. Will be used throughout 3 scenes.
    /// </summary>

    [Header("UI")] //The Main UI
    public GameObject UI;
    public GameObject buttonResume;
    public GameObject buttonBackMain;
    public GameObject buttonQuit;
    public GameObject BlackFade;

    [Header("Wave")]
    public GameObject Wave;
    public GameObject WaveCounter;

    public bool isPaused = false;

    public void Start()
    {
        buttonResume.SetActive(false);
        buttonBackMain.SetActive(false);
        buttonQuit.SetActive(false);
        BlackFade.SetActive(false);

        Wave.SetActive(true);
        WaveCounter.SetActive(true);
        UI.SetActive(true);
    }

    // The Game Pause
    public void TogglePause()
    {
        isPaused = !isPaused;

        Time.timeScale = isPaused ? 0 : 1;

        buttonResume.SetActive(true);
        buttonBackMain.SetActive(true);
        buttonQuit.SetActive(true);
        BlackFade.SetActive(true);

        Wave.SetActive(false);
        WaveCounter.SetActive(false);
        UI.SetActive(false);
    }

    // Unpause the game
    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1;

        buttonResume.SetActive(false);
        buttonBackMain.SetActive(false);
        buttonQuit.SetActive(false);
        BlackFade.SetActive(false);

        Wave.SetActive(true);
        WaveCounter.SetActive(true);
        UI.SetActive(true);
    }

    // Quit Button
    public void Quit_Application_1()
    {
        Application.Quit();
    }

    // Go Back To Main
    public void BackToMainMenu()
    {
        isPaused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("Starting Screen");
    }
}
