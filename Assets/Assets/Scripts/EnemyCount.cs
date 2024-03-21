using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCount : MonoBehaviour
{
    [Header("Enemy Count")]
    public int EnemyC;

    private void Start()
    {
        EnemyC = 0;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyC++;
        }
    }
}
