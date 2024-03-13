using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    /// <summary>
    /// YES. KILL.
    /// </summary>

    [Header("Player Attack")]
    public float DefaultAttack;
    public GameObject AttackCollision;
    public bool Attacking;

    [Header("Player Attack Speed")]
    public float AttackSpeed;
    public float CurrentAttackSpeed;
    public float cooldown;

    [Header("Animation")]
    public Animator MC;

    // Start is called before the first frame update
    void Start()
    {
        Attacking = false;

        AttackCollision.SetActive(true);
        DefaultAttack = 2f;
        AttackSpeed = 0.5f;
        CurrentAttackSpeed = AttackSpeed;
        cooldown = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentAttackSpeed >= AttackSpeed)
        {
            if (Input.GetMouseButtonDown(0))
            {
                AttackStart();
            }
        } else
        {
            AttackDone();
        }

        if (Attacking == true)
        {
            Debug.Log("Swinging");
        }
    } 

    private void AttackStart()
    {
        MC.GetComponent<Animator>().Play("Attack");
        Attacking = true;
        CurrentAttackSpeed = 0f;
    }

    private void AttackDone()
    {
        Attacking = false;
        CurrentAttackSpeed += cooldown * Time.deltaTime;
    }
}
