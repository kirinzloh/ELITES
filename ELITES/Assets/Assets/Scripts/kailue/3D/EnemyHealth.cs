using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;

    bool isDead;


    void Start()
    {
        currentHealth = startingHealth;
    }


    void Update()
    {

    }

    public void TakeDamage(int amount)
    {


        Debug.Log("Enemy Damaged");

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
        Destroy(gameObject, 2f);

    }
}
