using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [Header("Scripts")]
    public EnemyCount ec;

    [Header("Enemy Randomizer")]
    public GameObject[] RandomEnemy;
    public GameObject EnemyPicker;

    [Header("Spawn Randomizer")]
    public Transform[] RandomSpawn;
    public Transform SpawnPicker;

    [Header("Time")]
    public float tick;
    public float seconds;
    public float wave;

    // Start is called before the first frame update
    void Start()
    {
        tick = 1f;
        wave = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (ec.EnemyC >= 60) //This should be 30 but the OnTriggerEnter keeps on- yeah.
        {
            CalcTime();
            EnemyR();
            SpawnR();
        }

        
    }

    public void CalcTime() // Used to calculate sec, min and hours
    {
        seconds += Time.fixedDeltaTime * tick; // multiply time between fixed update by tick

        if (seconds >= wave) // 60 sec = 1 min
        {
            seconds = 0;
            Debug.Log("Enemy Spawn!");
        }
    }

    private void EnemyR()
    {
        EnemyPicker = RandomEnemy[Random.Range(0, RandomEnemy.Length)];
    }

    private void SpawnR()
    {
        SpawnPicker = RandomSpawn[Random.Range(0, RandomEnemy.Length)];
    }
}
