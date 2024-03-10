using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public PlayerAttack playerAttack;

    public float EnemyHealth;
    public float EnemySpeed;
    public float EnemyAttack;
    public bool isHunger, isWifi, isDepression, isSickness, isPower;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPower)
        {
            bossPower();
        }
        if (isSickness)
        {
            bossSickness();
        }
        if (isDepression)
        {
            enemyDepression();
        }
        if (isWifi)
        {
            enemyWifi();
        }
        if (isHunger)
        {
            enemyHunger();
        }
    }

    void bossPower()
    {
        //INSERT POWER
    }
    void bossSickness()
    {
        //INSERT POWER
    }
    void enemyDepression()
    {
        //INSERT POWER
    }
    void enemyWifi()
    {
        //INSERT POWER
    }
    void enemyHunger()
    {
        //INSERT POWER
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("PlayerAttack"))
        {
            EnemyHealth = EnemyHealth - playerAttack.DefaultAttack;
        }
    }
}
