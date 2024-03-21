using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Scripts")]
    public Enemy enemy;
    public DevsHealth devs;

    [Header("Movement")]
    public Vector3 currentEulerAngles;
    public Transform Goal;
    public GameObject Devs;


    private void Start()
    {
        //Getting some stuff
        enemy = GetComponent<Enemy>();
        Devs = GameObject.FindWithTag("Devs");
        Goal = Devs.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(this.transform.position, Goal.position, enemy.EnemyCurrentSpeed * Time.deltaTime);
    }
}
