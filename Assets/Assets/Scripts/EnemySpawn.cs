using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [Header("Scripts")]
    public EnemyCount ec;
    public WaveMechanic wm;

    [Header("Enemy Randomizer")]
    public GameObject[] RandomEnemy;
    public GameObject EnemyPicker;

    [Header("Boss Randomizer")]
    public GameObject[] RandomBoss;
    public GameObject BossPicker;

    [Header("Spawn Randomizer")]
    public Transform[] RandomSpawn;
    public Transform SpawnPicker;

    [Header("Time")]
    public float tick;
    public float Eseconds;
    public float Bseconds;
    public float Eevery;
    public float Bevery;

    // Start is called before the first frame update
    void Start()
    {
        tick = 1f;
        Eevery = 3f;
        Bevery = 30f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (ec.EnemyC <= 60) //This should be 30 but the OnTriggerEnter keeps on- yeah.
        {
            EnemyCalc();
            BossCalc();
            //EnemyR();
            //BossR();
            //SpawnR();
        }
    }

    public void EnemyCalc() // Enemy
    {
        Eseconds += Time.fixedDeltaTime * tick; // multiply time between fixed update by tick

        if (Eseconds >= Eevery) 
        {
            //Instantiate(EnemyPicker, SpawnPicker);

            Eseconds = 0;
        }
    }

    public void BossCalc() // Boss
    {
        Bseconds += Time.fixedDeltaTime * tick; // multiply time between fixed update by tick

        if (Bseconds >= Bevery)
        {
            BossPicker = RandomBoss[Random.Range(0, RandomBoss.Length)];
            SpawnPicker = RandomSpawn[Random.Range(0, RandomEnemy.Length)];
            Instantiate(BossPicker, SpawnPicker);

            Bseconds = 0;
        }
    }

    private void EnemyR()
    {
        EnemyPicker = RandomEnemy[Random.Range(0, RandomEnemy.Length)];
    }
    private void BossR()
    {
        BossPicker = RandomBoss[Random.Range(0, RandomBoss.Length)];
    }

    private void SpawnR()
    {
        SpawnPicker = RandomSpawn[Random.Range(0, RandomEnemy.Length)];
    }
}
