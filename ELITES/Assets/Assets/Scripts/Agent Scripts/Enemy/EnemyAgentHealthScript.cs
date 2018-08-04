using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAgentHealthScript : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;
    //public int scoreValue = 10;
    GameObject enemySprite;
    public float stunDuration;

    EnemyAgentMovementScript enemyMovement;

    bool isDead;
    float timer;


    void Start ()
    {
        currentHealth = startingHealth;
        enemySprite = GameObject.FindGameObjectWithTag("BlankSprite");
        enemySprite.tag = "Untagged";
    }


    void Update()
    {
        enemyMovement = GetComponent<EnemyAgentMovementScript>();

    }

    private void LateUpdate()
    {
        timer += Time.deltaTime;

        if (timer >= stunDuration && Time.timeScale != 0)
        {
            enemyMovement.SetSpeed(0.5f);
            
        }
    }

    public void TakeDamage(int amount)
    {
        

        Debug.Log("Enemy Damaged");
        enemyMovement.SetSpeed(0f);
        timer = 0f;

        if (isDead)
            return;
        

        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Death();
        }
    }


    void Death()
    {
        isDead = true;
        Destroy(enemySprite.gameObject, 2f);
        Destroy(gameObject, 2f);

    }


    
}
