using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float DefaultAttack;
    public GameObject AttackCollision;

    // Start is called before the first frame update
    void Start()
    {
        AttackCollision.SetActive(false);
        DefaultAttack = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Atack");
            AttackCollision.SetActive(true);
        }
        else
        {
            AttackCollision.SetActive(false);
        }
    }
}
