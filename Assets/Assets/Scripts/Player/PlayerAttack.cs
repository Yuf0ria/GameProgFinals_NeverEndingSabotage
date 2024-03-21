using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Scripts")]
    public PlayerMovement pm;
    public DevsHealth dh;

    /// <summary>
    /// YES. KILL.
    /// </summary>

    [Header("Player Attack")]
    public float DefaultAttack;
    public float MaxAttack;
    public GameObject AttackCollision;
    public Transform AttackSummon;

    /// <summary>
    /// YES. POWERFUL KILL.
    /// </summary>

    [Header("Mana")]
    public float maxMana;
    public float currentMana;

    [Header("ManaRegen")]
    public float dValueR;
    public float dValueD;

    [Header("Skill And Cost")] // I KNOW I can do this better, but my brain is not allowing me to look up things right now.
    public float damageIncrease; //Lol I believe in u, Sean.
    public bool Skill;
    public bool Drain;
    public bool Restore;

    /// <summary>
    /// ANIMATION/MISC.
    /// </summary>

    [Header("Animation")]
    public Animator MC;

    [Header("ManaUI")]
    public GameObject Mana1;
    public GameObject Mana2;
    public GameObject Mana3;
    public GameObject Mana4;
    public GameObject Mana5;
    public GameObject Mana6;
    public GameObject Mana7;
    public GameObject Mana8;
    public GameObject Mana9;
    public GameObject Mana10;

    [Header("ManaCapUI")]
    public GameObject ManaCap1;
    public GameObject ManaCap2;
    public GameObject ManaCap3;
    public GameObject ManaCap4;
    public GameObject ManaCap5;

    // Start is called before the first frame update
    void Start()
    {
        AttackCollision.SetActive(true);
        DefaultAttack = 2f;
        MaxAttack = DefaultAttack;

        //Mana
        maxMana = 2f;
        dValueR = 1f;
        dValueD = 1f;
        currentMana = maxMana;
        Skill = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //Attacking
        {
            MC.GetComponent<Animator>().Play("Attack");
        }

        if (Input.GetMouseButtonDown(1)) //Using Mana
        {
            if (currentMana >= maxMana)
            {
                Skill = true;
            }
        }

        //When using Skill
        if (Skill)//Greatly Increase Attack
        {
            MaxAttack = DefaultAttack * 1.5f;
            pm.MaxmoveSpeed = pm.moveSpeed * 1.5f;
            dh.CurrentdValue = dh.dValue * 1.5f;

        } else//Go back to normal
        {
            MaxAttack = DefaultAttack;
            pm.MaxmoveSpeed = pm.moveSpeed;
            dh.CurrentdValue = dh.dValue;
        }

        Mana();
        ManaUI();
        ManaCapUI();
    } 

    void Mana() //Mana functions
    {
        if (Drain)
        {
            DrainMana();
        }
        if (Restore)
        {
            RestoreMana();
        }

        if (Skill == true)
        {
            Drain = true;
        }

        if (currentMana < 1)
        {
            Skill = false;
            Drain = false;
            Restore = true;
        }

        if (currentMana >= maxMana)
        {
            Restore = false;
        }
    }

    private void RestoreMana() //Restoring Mana
    {
        currentMana += dValueR * Time.deltaTime; //The regeneration part
    }

    private void DrainMana() //Draining Mana
    {
        currentMana -= dValueD * Time.deltaTime; //The draining part
    }

    public void ManaUI() //Yep.
    {
        if (currentMana >= 10f)
        {
            Mana1.SetActive(true);
            Mana2.SetActive(true);
            Mana3.SetActive(true);
            Mana4.SetActive(true);
            Mana5.SetActive(true);
            Mana6.SetActive(true);
            Mana7.SetActive(true);
            Mana8.SetActive(true);
            Mana9.SetActive(true);
            Mana10.SetActive(true);
        }
        else
        if (currentMana >= 9f)
        {
            Mana1.SetActive(true);
            Mana2.SetActive(true);
            Mana3.SetActive(true);
            Mana4.SetActive(true);
            Mana5.SetActive(true);
            Mana6.SetActive(true);
            Mana7.SetActive(true);
            Mana8.SetActive(true);
            Mana9.SetActive(true);
            Mana10.SetActive(false);
        }
        else
        if (currentMana >= 8f)
        {
            Mana1.SetActive(true);
            Mana2.SetActive(true);
            Mana3.SetActive(true);
            Mana4.SetActive(true);
            Mana5.SetActive(true);
            Mana6.SetActive(true);
            Mana7.SetActive(true);
            Mana8.SetActive(true);
            Mana9.SetActive(false);
            Mana10.SetActive(false);
        }
        else
        if (currentMana >= 7f)
        {
            Mana1.SetActive(true);
            Mana2.SetActive(true);
            Mana3.SetActive(true);
            Mana4.SetActive(true);
            Mana5.SetActive(true);
            Mana6.SetActive(true);
            Mana7.SetActive(true);
            Mana8.SetActive(false);
            Mana9.SetActive(false);
            Mana10.SetActive(false);
        }
        else
        if (currentMana >= 6f)
        {
            Mana1.SetActive(true);
            Mana2.SetActive(true);
            Mana3.SetActive(true);
            Mana4.SetActive(true);
            Mana5.SetActive(true);
            Mana6.SetActive(true);
            Mana7.SetActive(false);
            Mana8.SetActive(false);
            Mana9.SetActive(false);
            Mana10.SetActive(false);
        }
        else
        if (currentMana >= 5f)
        {
            Mana1.SetActive(true);
            Mana2.SetActive(true);
            Mana3.SetActive(true);
            Mana4.SetActive(true);
            Mana5.SetActive(true);
            Mana6.SetActive(false);
            Mana7.SetActive(false);
            Mana8.SetActive(false);
            Mana9.SetActive(false);
            Mana10.SetActive(false);
        }
        else
        if (currentMana >= 4f)
        {
            Mana1.SetActive(true);
            Mana2.SetActive(true);
            Mana3.SetActive(true);
            Mana4.SetActive(true);
            Mana5.SetActive(false);
            Mana6.SetActive(false);
            Mana7.SetActive(false);
            Mana8.SetActive(false);
            Mana9.SetActive(false);
            Mana10.SetActive(false);
        }
        else
        if (currentMana >= 3f)
        {
            Mana1.SetActive(true);
            Mana2.SetActive(true);
            Mana3.SetActive(true);
            Mana4.SetActive(false);
            Mana5.SetActive(false);
            Mana6.SetActive(false);
            Mana7.SetActive(false);
            Mana8.SetActive(false);
            Mana9.SetActive(false);
            Mana10.SetActive(false);
        }
        else
        if (currentMana >= 2f)
        {
            Mana1.SetActive(true);
            Mana2.SetActive(true);
            Mana3.SetActive(false);
            Mana4.SetActive(false);
            Mana5.SetActive(false);
            Mana6.SetActive(false);
            Mana7.SetActive(false);
            Mana8.SetActive(false);
            Mana9.SetActive(false);
            Mana10.SetActive(false);
        }
        else
        if (currentMana >= 1f)
        {
            Mana1.SetActive(true);
            Mana2.SetActive(false);
            Mana3.SetActive(false);
            Mana4.SetActive(false);
            Mana5.SetActive(false);
            Mana6.SetActive(false);
            Mana7.SetActive(false);
            Mana8.SetActive(false);
            Mana9.SetActive(false);
            Mana10.SetActive(false);
        }
        else
        if (currentMana >= 0f)
        {
            Mana1.SetActive(false);
            Mana2.SetActive(false);
            Mana3.SetActive(false);
            Mana4.SetActive(false);
            Mana5.SetActive(false);
            Mana6.SetActive(false);
            Mana7.SetActive(false);
            Mana8.SetActive(false);
            Mana9.SetActive(false);
            Mana10.SetActive(false);
        }
    }

    public void ManaCapUI() //Mhm.
    {
        if (maxMana <= 2f)
        {
            ManaCap1.SetActive(true);
            ManaCap2.SetActive(false);
            ManaCap3.SetActive(false);
            ManaCap4.SetActive(false);
            ManaCap5.SetActive(false);
        }
        else
        if (maxMana <= 4f)
        {
            ManaCap1.SetActive(true);
            ManaCap2.SetActive(true);
            ManaCap3.SetActive(false);
            ManaCap4.SetActive(false);
            ManaCap5.SetActive(false);
        }
        else
        if (maxMana <= 6f)
        {
            ManaCap1.SetActive(true);
            ManaCap2.SetActive(true);
            ManaCap3.SetActive(true);
            ManaCap4.SetActive(false);
            ManaCap5.SetActive(false);
        }
        else
        if (maxMana <= 8f)
        {
            ManaCap1.SetActive(true);
            ManaCap2.SetActive(true);
            ManaCap3.SetActive(true);
            ManaCap4.SetActive(true);
            ManaCap5.SetActive(false);
        }
        else
        if (maxMana <= 10f)
        {
            ManaCap1.SetActive(true);
            ManaCap2.SetActive(true);
            ManaCap3.SetActive(true);
            ManaCap4.SetActive(true);
            ManaCap5.SetActive(true);
        }
    }
}
