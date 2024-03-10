using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public PlayerAttack playerAttack;

    public float EnemyHealth;
    public float EnemySpeed;
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
    }

    void bossPower()
    {
        //EnemyHealth = 20f;
        //EnemySpeed = 9f;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("PlayerAttack"))
        {
            EnemyHealth = EnemyHealth - playerAttack.DefaultAttack;
        }
    }
}
