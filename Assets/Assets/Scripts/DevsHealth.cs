using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevsHealth : MonoBehaviour
{
    /// <summary>
    /// THE DEV'S HEALTH AND REGENERATION. THAT'S IT.
    /// </summary>

    [Header("Scripts")]
    public MainButtons mb;
    public PlayerMovement pm;

    [Header("Health")]
    public float maxHealth;
    public float currentHealth;
    public bool dead;

    [Header("Regenration")]
    public float dValue;
    public float CurrentdValue;
    public float restore;

    [Header("HealthUI")]
    public GameObject Health1;
    public GameObject Health2;
    public GameObject Health3;
    public GameObject Health4;
    public GameObject Health5;
    public GameObject Health6;
    public GameObject Health7;
    public GameObject Health8;
    public GameObject Health9;
    public GameObject Health10;

    [Header("HealthCapUI")]
    public GameObject HealthCap1;
    public GameObject HealthCap2;
    public GameObject HealthCap3;
    public GameObject HealthCap4;
    public GameObject HealthCap5;

    [Header("GameOverUI")]
    public GameObject GameOverText;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 2f;
        dValue = 0.6f;
        currentHealth = maxHealth;
        dead = false;
        CurrentdValue = dValue;
        restore = 0f;

        GameOverText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        GameOver();
        if (currentHealth < maxHealth && dead == false) //If current health is not full
        {
            Regeneration();
        }
        HealthUI();
        HealthCapUI();
        RestoreRegen();
    }

    private void Regeneration()
    {
        currentHealth += CurrentdValue * Time.deltaTime; //The regeneration part
    }

    //Recovering from debuffs
    private void RestoreRegen()
    {
        if (CurrentdValue != dValue)
        {
            if (restore >= 2)
            {
                CurrentdValue = dValue;
                restore = 0f;
            } else
            {
                restore += 0.5f * Time.deltaTime;
            }
        }
    }

    public void GameOver() //The Only Game Over
    {
        if (currentHealth <= 0f)
        {
            dead = true;
        }

        if (dead == true)
        {
            pm.moveSpeed = 0f;

            mb.buttonBackMain.SetActive(true);
            mb.buttonQuit.SetActive(true);
            GameOverText.SetActive(true);

            mb.buttonPause.SetActive(false);
            mb.Mana.SetActive(false);
            mb.Health.SetActive(false);
        }
    }

    public void HealthUI() //Jesus christ. There should be a convenient way of doing this but at 3:34PM on 11/03/2024 my brain is fried.
    {


        if (currentHealth >= 10f)
        {
            Health1.SetActive(true);
            Health2.SetActive(true);
            Health3.SetActive(true);
            Health4.SetActive(true);
            Health5.SetActive(true);
            Health6.SetActive(true);
            Health7.SetActive(true);
            Health8.SetActive(true);
            Health9.SetActive(true);
            Health10.SetActive(true);
        } else
        if (currentHealth >= 9f)
        {
            Health1.SetActive(true);
            Health2.SetActive(true);
            Health3.SetActive(true);
            Health4.SetActive(true);
            Health5.SetActive(true);
            Health6.SetActive(true);
            Health7.SetActive(true);
            Health8.SetActive(true);
            Health9.SetActive(true);
            Health10.SetActive(false);
        } else
        if (currentHealth >= 8f)
        {
            Health1.SetActive(true);
            Health2.SetActive(true);
            Health3.SetActive(true);
            Health4.SetActive(true);
            Health5.SetActive(true);
            Health6.SetActive(true);
            Health7.SetActive(true);
            Health8.SetActive(true);
            Health9.SetActive(false);
            Health10.SetActive(false);
        } else
        if (currentHealth >= 7f)
        {
            Health1.SetActive(true);
            Health2.SetActive(true);
            Health3.SetActive(true);
            Health4.SetActive(true);
            Health5.SetActive(true);
            Health6.SetActive(true);
            Health7.SetActive(true);
            Health8.SetActive(false);
            Health9.SetActive(false);
            Health10.SetActive(false);
        } else
        if (currentHealth >= 6f)
        {
            Health1.SetActive(true);
            Health2.SetActive(true);
            Health3.SetActive(true);
            Health4.SetActive(true);
            Health5.SetActive(true);
            Health6.SetActive(true);
            Health7.SetActive(false);
            Health8.SetActive(false);
            Health9.SetActive(false);
            Health10.SetActive(false);
        } else
        if (currentHealth >= 5f)
        {
            Health1.SetActive(true);
            Health2.SetActive(true);
            Health3.SetActive(true);
            Health4.SetActive(true);
            Health5.SetActive(true);
            Health6.SetActive(false);
            Health7.SetActive(false);
            Health8.SetActive(false);
            Health9.SetActive(false);
            Health10.SetActive(false);
        } else
        if (currentHealth >= 4f)
        {
            Health1.SetActive(true);
            Health2.SetActive(true);
            Health3.SetActive(true);
            Health4.SetActive(true);
            Health5.SetActive(false);
            Health6.SetActive(false);
            Health7.SetActive(false);
            Health8.SetActive(false);
            Health9.SetActive(false);
            Health10.SetActive(false);
        } else
        if (currentHealth >= 3f)
        {
            Health1.SetActive(true);
            Health2.SetActive(true);
            Health3.SetActive(true);
            Health4.SetActive(false);
            Health5.SetActive(false);
            Health6.SetActive(false);
            Health7.SetActive(false);
            Health8.SetActive(false);
            Health9.SetActive(false);
            Health10.SetActive(false);
        } else
        if (currentHealth >= 2f)
        {
            Health1.SetActive(true);
            Health2.SetActive(true);
            Health3.SetActive(false);
            Health4.SetActive(false);
            Health5.SetActive(false);
            Health6.SetActive(false);
            Health7.SetActive(false);
            Health8.SetActive(false);
            Health9.SetActive(false);
            Health10.SetActive(false);
        } else
        if (currentHealth >= 1f)
        {
            Health1.SetActive(true);
            Health2.SetActive(false);
            Health3.SetActive(false);
            Health4.SetActive(false);
            Health5.SetActive(false);
            Health6.SetActive(false);
            Health7.SetActive(false);
            Health8.SetActive(false);
            Health9.SetActive(false);
            Health10.SetActive(false);
        } else
        if (currentHealth >= 0f)
        {
            Health1.SetActive(false);
            Health2.SetActive(false);
            Health3.SetActive(false);
            Health4.SetActive(false);
            Health5.SetActive(false);
            Health6.SetActive(false);
            Health7.SetActive(false);
            Health8.SetActive(false);
            Health9.SetActive(false);
            Health10.SetActive(false);
        }  
    }

    public void HealthCapUI() //18/03/2024 10:14PM I'm still doing the same thing.
    {
        if (maxHealth <= 2f)
        {
            HealthCap1.SetActive(true);
            HealthCap2.SetActive(false);
            HealthCap3.SetActive(false);
            HealthCap4.SetActive(false);
            HealthCap5.SetActive(false);
        }
        else
        if (maxHealth <= 4f)
        {
            HealthCap1.SetActive(true);
            HealthCap2.SetActive(true);
            HealthCap3.SetActive(false);
            HealthCap4.SetActive(false);
            HealthCap5.SetActive(false);
        }
        else
        if (maxHealth <= 6f)
        {
            HealthCap1.SetActive(true);
            HealthCap2.SetActive(true);
            HealthCap3.SetActive(true);
            HealthCap4.SetActive(false);
            HealthCap5.SetActive(false);
        }
        else
        if (maxHealth <= 8f)
        {
            HealthCap1.SetActive(true);
            HealthCap2.SetActive(true);
            HealthCap3.SetActive(true);
            HealthCap4.SetActive(true);
            HealthCap5.SetActive(false);
        }
        else
        if (maxHealth <= 10f)
        {
            HealthCap1.SetActive(true);
            HealthCap2.SetActive(true);
            HealthCap3.SetActive(true);
            HealthCap4.SetActive(true);
            HealthCap5.SetActive(true);
        }
    }
}
