using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EXPManager : MonoBehaviour
{
    [Header("Scripts")]
    public LevelUP lvl;
    public MainButtons mb;

    [Header("Experience")]
    [SerializeField] AnimationCurve EXPCurve;
    int currentLevel;
    int totalEXP;
    int previousLevelEXP;
    int nextLevelEXP;


    [Header("Interface")]
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI EXPText;
    [SerializeField] Image EXPFill;
    // Start is called before the first frame update
    void Start()
    {
        UpdateLevel();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.E)) // If you feel like cheating I guess.
        {
            AddExperience(5);
        }
    }

    public void AddExperience(int amount)
    {
        totalEXP += amount;
        CheckForLevelUp();
        UpdateInterface();
    }

    void CheckForLevelUp()
    {
        if (totalEXP >= nextLevelEXP)
        {
            currentLevel++;
            UpdateLevel();

            //Level Up
            lvl.LevelUpGroup.SetActive(true);
            mb.BlackFade.SetActive(true);

            mb.Wave.SetActive(false);
            mb.WaveCounter.SetActive(false);
            mb.UI.SetActive(false);

            mb.isPaused = !mb.isPaused;
            Time.timeScale = mb.isPaused ? 0 : 1;
        }
    }

    void UpdateLevel()
    {
        previousLevelEXP = (int)EXPCurve.Evaluate(currentLevel);
        nextLevelEXP = (int)EXPCurve.Evaluate(currentLevel + 1);
        UpdateInterface();
    }

    void UpdateInterface()
    {
        int start = totalEXP - previousLevelEXP;
        int end = nextLevelEXP - previousLevelEXP;

        levelText.text = currentLevel.ToString();
        EXPText.text = "EXP: " + start + "/" + end;
        EXPFill.fillAmount = (float)start / (float)end;
    }
}
