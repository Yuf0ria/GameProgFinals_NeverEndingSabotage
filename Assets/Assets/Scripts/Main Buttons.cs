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
    public GameObject buttonResume;
    public GameObject buttonBackMain;
    public GameObject buttonQuit;
    public GameObject buttonPause;
    public GameObject Health;
    public GameObject Mana;

    [Header("Wave")]
    public GameObject Wave;
    public GameObject WaveCounter;

    private bool isPaused = false;

    public void Start()
    {
        buttonResume.SetActive(false);
        buttonBackMain.SetActive(false);
        buttonQuit.SetActive(false);

        Wave.SetActive(true);
        WaveCounter.SetActive(true);
        buttonPause.SetActive(true);
        Mana.SetActive(true);
        Health.SetActive(true);
    }

    // The Game Pause
    public void TogglePause()
    {
        isPaused = !isPaused;

        Time.timeScale = isPaused ? 0 : 1;

        buttonResume.SetActive(true);
        buttonBackMain.SetActive(true);
        buttonQuit.SetActive(true);
        
        Wave.SetActive(false);
        WaveCounter.SetActive(false);
        buttonPause.SetActive(false);
        Mana.SetActive(false);
        Health.SetActive(false);
    }

    // Unpause the game
    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1;

        buttonResume.SetActive(false);
        buttonBackMain.SetActive(false);
        buttonQuit.SetActive(false);

        Wave.SetActive(true);
        WaveCounter.SetActive(true);
        buttonPause.SetActive(true);
        Mana.SetActive(true);
        Health.SetActive(true);
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
