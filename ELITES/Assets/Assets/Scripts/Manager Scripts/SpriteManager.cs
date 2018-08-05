using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour {

    GameObject agent;
    public GameObject enemySprite;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;


    void Start()
    {
        agent = GameObject.FindGameObjectWithTag("BlankEnemy");
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }


    void Spawn()
    {

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        Instantiate(enemySprite, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
