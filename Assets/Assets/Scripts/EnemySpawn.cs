using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [Header("Scripts")]
    public EnemyCount ec;
    public WaveMechanic wm;

    [Header("Randomizer")]
    public GameObject[] RandomEnemy;
    public GameObject[] RandomBoss;
    public Transform[] RandomSpawn;

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
        Eevery = 5f;
        Bevery = 60f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (ec.EnemyC <= 60) //This should be 30 but the OnTriggerEnter keeps on- yeah.
        {
            EnemyCalc();
            BossCalc();
        }
    }

    public void EnemyCalc() // Enemy
    {
        Eseconds += Time.fixedDeltaTime * tick; // multiply time between fixed update by tick

        if (Eseconds >= Eevery) 
        {
            int E = Random.Range(0, RandomEnemy.Length);
            int Se = Random.Range(0, RandomSpawn.Length);

            Instantiate(RandomEnemy[E], RandomSpawn[Se]);

            Eseconds = 0;
        }
    }

    public void BossCalc() // Boss
    {
        Bseconds += Time.fixedDeltaTime * tick; // multiply time between fixed update by tick

        if (Bseconds >= Bevery)
        {
            int B = Random.Range(0, RandomBoss.Length);
            int Sb = Random.Range(0, RandomSpawn.Length);

            Instantiate(RandomBoss[B], RandomSpawn[Sb]);

            Bseconds = 0;
        }
    }
}
