using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    /// <summary>
    /// YES. KILL.
    /// </summary>

    [Header("Player Attack")]
    public float DefaultAttack;
    public GameObject AttackCollision;

    [Header("Animation")]
    public Animator MC;
    public SpriteRenderer character;

    // Start is called before the first frame update
    void Start()
    {
        AttackCollision.SetActive(false);
        DefaultAttack = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Atack");
            MC.GetComponent<Animator>().Play("Attack");
            AttackCollision.SetActive(true);
        }
        else
        {
            AttackCollision.SetActive(false);
        }
    }
}
