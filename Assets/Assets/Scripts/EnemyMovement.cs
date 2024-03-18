using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Scripts")]
    public Enemy enemy;

    [Header("Movement")]
    public Vector3 currentEulerAngles;
    public Transform Devs;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(this.transform.position, Devs.position, enemy.EnemyCurrentSpeed * Time.deltaTime);
    }
}
