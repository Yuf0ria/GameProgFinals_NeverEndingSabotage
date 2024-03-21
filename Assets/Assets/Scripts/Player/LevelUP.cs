using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUP : MonoBehaviour
{
    [Header("Scripts")]
    public DevsHealth dh;
    public PlayerAttack pa;
    public EXPManager exp;
    public MainButtons mb;

    [Header("UI")]
    public GameObject LevelUpGroup;
    public GameObject ManaButton;
    public GameObject HealthButton;

    public void AtkUP()
    {
        pa.DefaultAttack = pa.DefaultAttack * 1.4f;
        BackToGame();
    }

    public void HealthUP()
    {
        dh.maxHealth = dh.maxHealth + 2;
        if (dh.maxHealth == 10)
        {
            HealthButton.SetActive(false);
        }
        dh.currentHealth = dh.maxHealth;
        BackToGame();
    }

    public void ManaUP()
    {
        pa.maxMana = pa.maxMana + 2f;
        if (pa.maxMana == 10)
        {
            ManaButton.SetActive(false);
        }
        pa.currentMana = pa.maxMana;
        BackToGame();
    }

    void BackToGame()
    {
        LevelUpGroup.SetActive(false);
        mb.BlackFade.SetActive(false);

        mb.Wave.SetActive(true);
        mb.WaveCounter.SetActive(true);
        mb.UI.SetActive(true);

        mb.isPaused = false;
        Time.timeScale = 1;
    }
}
