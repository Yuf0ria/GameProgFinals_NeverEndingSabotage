using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    /// <summary>
    /// ENEMIES. ALL ENEMIES AND BOSSES
    /// </summary>

    [Header("Scripts")] ///
    public PlayerAttack playerAttack;
    public DevsHealth devHealth;
    public WaveMechanic wm;
    public EXPManager exp;
    public EnemyCount ec;

    [Header("Enemy Health")]
    public float EnemyHealth;
    public float EnemyCurrentHealth;

    [Header("Enemy Movement")]
    public float EnemySpeed;
    public float EnemyCurrentSpeed;

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

    [Header("EXP")]
    public int EXPDrop;

    [Header("Enemy Identity")]
    public bool isHunger;
    public bool isWifi;
    public bool isDepression;
    public bool isSickness;
    public bool isPower;

    [Header("Animation")]
    public Animator EnemyAnimation;

    [Header("Enemy Wave Mechanic")]
    public int wave; //It's a getting closer-

    [Header("UI")]
    public TextMeshPro health;

    // Start is called before the first frame update
    void Start()
    {
        playerAttack = FindObjectOfType<PlayerAttack>();
        devHealth = FindObjectOfType<DevsHealth>();
        wm = FindObjectOfType<WaveMechanic>();
        exp = FindObjectOfType<EXPManager>();
        ec = FindObjectOfType<EnemyCount>();

        health = GetComponentInChildren<TextMeshPro>();

        wave = 1;

        if (isPower)
        {
            //Basic
            EnemyAttack = 5f; //Attack
            EnemyHealth = 20f; //Health
            EnemySpeed = 6f; //Movement
            EnemyAttackSpeed = 9f; //AttackSpeed
            EXPDrop = 25; //EXP DROP
        }
        if (isSickness)
        {           
            EnemyAttack = 4f; //Attack
            EnemyHealth = 16f; //Health
            EnemySpeed = 3f; //Movement
            EnemyAttackSpeed = 9f;  //AttackSpeed
            EXPDrop = 20; //EXP DROP
        }
        if (isDepression)
        {            
            EnemyAttack = 0.5f; //Attack           
            EnemyHealth = 13f; //Health            
            EnemySpeed = 5f; //Movement
            EnemyAttackSpeed = 1f; //AttackSpeed
            EXPDrop = 15; //EXP DROP
        }
        if (isWifi)
        {           
            EnemyAttack = 2f; //Attack           
            EnemyHealth = 13f; //Health
            EnemySpeed = 7f; //Movement
            EnemyAttackSpeed = 5f; //AttackSpeed
            EXPDrop = 10; //EXP DROP
        }
        if (isHunger)
        {
            EnemyAttack = 1f; //Attack
            EnemyHealth = 10f; //Health
            EnemySpeed = 6f; //Movement
            EnemyAttackSpeed = 5f; //AttackSpeed
            EXPDrop = 5; //EXP DROP
        }

        //All
        EnemyCurrentHealth = EnemyHealth;
        EnemyCurrentAttackSpeed = EnemyAttackSpeed;
        EnemyCurrentSkillTimer = EnemySkillTimer;
        EnemyCurrentSkillCD = EnemySkillCD;
        EnemyCurrentSpeed = EnemySpeed;

        //Cooldowns
        EnemySkillCD = 10f;
        cooldown = 1f;

        //Animation Component
        EnemyAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyDead();
        EnemyUpgrade();

        health.text = EnemyCurrentHealth.ToString();
    }

    public void EnemyUpgrade() //Level up HP
    {
        if (wm.wavecount_update == wave)
        {
            EXPDrop = EXPDrop + 5;
            EnemyHealth = EnemyHealth * (1.5f);
            wave++;
        }
    }
    
    private void Attack() //Attack
    {
        if (EnemyCurrentAttackSpeed >= EnemyAttackSpeed) //If Cooldown Over
        {
            //Skills/Debuffs
            if (isPower || isWifi) // Stopping HP Restoration
            {
                devHealth.CurrentdValue = 0f;
            }
            if (isSickness || isDepression) // Decreasing HP Restoration
            {
                devHealth.CurrentdValue = 0.2f;
            }

            //Actual Attack
            EnemyAnimation.GetComponent<Animator>().Play("Attack");
            EnemyCurrentAttackSpeed = 0f;
            Debug.Log("EnemyAttack");

        } else //Cooldown regen
        {
            EnemyCurrentAttackSpeed += cooldown * Time.deltaTime;
        }
    }

    public void Attackblow()
    {
        devHealth.currentHealth = devHealth.currentHealth - EnemyAttack;
    }

    private void OnTriggerStay(Collider collision) //Colliding with devs
    {
        if (collision.CompareTag("Devs"))
        {
            Attack();
            EnemyCurrentSpeed = 0f;
        }
    }
    
    private void OnTriggerEnter(Collider collision) //Colliding with player
    {
        if (collision.CompareTag("PlayerAttack")) //When enemies recieve owie ow ow ouch yeouch from the intern
        {
            EnemyCurrentHealth = EnemyCurrentHealth - playerAttack.MaxAttack;
            Destroy(collision.gameObject);
        }
    }

    private void EnemyDead() //When you're dead.
    {
        if (EnemyCurrentHealth <= 0)
        {
            ec.EnemyC = ec.EnemyC - 2;
            exp.AddExperience(EXPDrop);
            Destroy(this.gameObject);
        }
    }
}
