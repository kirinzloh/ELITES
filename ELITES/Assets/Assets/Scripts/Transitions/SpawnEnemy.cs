using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {

    //public PlayerHealth playerHealth;
    public GameObject[] enemy;
    public float spawnTime = 2f;
    public Transform[] spawnPoints;
    public bool repeat;
    public int initialSpawn;

    private int enemySpawned = 0;


    void Start()
    {
        for (int i = 0; i < initialSpawn; i++)
        {

            Instantiate(enemy[i], spawnPoints[i].position, spawnPoints[i].rotation);
        }

        if (repeat)
        {

            InvokeRepeating("Spawn", spawnTime, spawnTime);
        }

    }


    void Spawn()


    {
        if (enemySpawned == enemy.Length)
        {
            return;
        }

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(enemy[enemySpawned], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        enemySpawned += 1;


    }
}
