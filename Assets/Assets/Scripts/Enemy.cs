using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    /// <summary>
    /// ENEMIES. ALL ENEMIES AND BOSSES
    /// </summary>

    [Header("Scripts")]
    public PlayerAttack playerAttack;
    public DevsHealth devHealth;

    [Header("Enemy Health")]
    public float EnemyHealth;

    [Header("Enemy Movement")]
    public float EnemySpeed;

    [Header("Enemy Attack")]
    public float EnemyAttack;

    [Header("Enemy Attack Speed")]
    public float EnemyAttackSpeed;
    public float EnemyCurrentAttackSpeed;
    public float cooldown;

    [Header("Skills")]
    public float EnemySkillTimer;
    public float EnemyCurrentSkillTimer;
    public float EnemySkillCD;
    public float EnemyCurrentSkillCD;

    [Header("Enemy Identity")]
    public bool isHunger;
    public bool isWifi;
    public bool isDepression;
    public bool isSickness;
    public bool isPower;

    // Start is called before the first frame update
    void Start()
    {

        if (isPower)
        {
            //Basic
            EnemyAttack = 5f; //Attack
            EnemyHealth = 20f; //Health
            EnemySpeed = 7f; //Movement
            EnemyAttackSpeed = 9f; //AttackSpeed

            //Skill
            EnemySkillTimer = 10f;
        }
        if (isSickness)
        {           
            EnemyAttack = 4f; //Attack
            EnemyHealth = 16f; //Health
            EnemySpeed = 6f; //Movement
            EnemyAttackSpeed = 9f;  //AttackSpeed
        }
        if (isDepression)
        {            
            EnemyAttack = 0.5f; //Attack           
            EnemyHealth = 13f; //Health            
            EnemySpeed = 6f; //Movement
            EnemyAttackSpeed = 1f; //AttackSpeed
        }
        if (isWifi)
        {           
            EnemyAttack = 2f; //Attack           
            EnemyHealth = 13f; //Health
            EnemySpeed = 8f; //Movement
            EnemyAttackSpeed = 5f; //AttackSpeed
        }
        if (isHunger)
        {
            EnemyAttack = 1f; //Attack
            EnemyHealth = 10f; //Health
            EnemySpeed = 7f; //Movement
            EnemyAttackSpeed = 5f; //AttackSpeed
        }

        //All
        EnemyCurrentAttackSpeed = EnemyAttackSpeed;
        EnemyCurrentSkillTimer = EnemySkillTimer;
        EnemyCurrentSkillCD = EnemySkillCD;

        //Cooldowns
        EnemySkillCD = 10f;
        cooldown = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyDead();
    }

    //Attack
    private void Attack() //Honestly my proudest line of code idk
    {
        if (EnemyCurrentAttackSpeed >= EnemyAttackSpeed) //If Cooldown Over
        {
            //Skills/Debuffs
            if (isPower || isWifi)
            {
                devHealth.CurrentdValue = 0f;
            }
            if (isSickness || isDepression)
            {
                devHealth.CurrentdValue = 0.2f;
            }

            //Actual Attack
            devHealth.currentHealth = devHealth.currentHealth - EnemyAttack;
            EnemyCurrentAttackSpeed = 0f;
            Debug.Log("EnemyAttack");

        } else //Cooldown regen
        {
            EnemyCurrentAttackSpeed += cooldown * Time.deltaTime;
        }
    }

    //Collision with Player and Devs
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("PlayerAttack"))
        {
            EnemyHealth = EnemyHealth - playerAttack.DefaultAttack;
        }

        if (collision.CompareTag("Devs"))
        {
            Debug.Log("Enemy Is Here");
            Attack();
            EnemySpeed = 0f;
        }
    }

    private void EnemyDead()
    {
        if (EnemyHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
