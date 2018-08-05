using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAgentHealthScript : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;

    //Animator anim;
    PlayerAgentMovementScript playerMovement;
    PlayerAgentAttackScript playerAttacking;
    bool isDead;
    //bool damaged;
	

    void Start ()
    {
        //anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerAgentMovementScript>();
        playerAttacking = GetComponent<PlayerAgentAttackScript>();
        currentHealth = startingHealth;
    }


    void Update()
    {
        
    }


    public void TakeDamage(int amount)
    {
        //damaged = true;
        currentHealth -= amount;

        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }


    void Death()
    {
        isDead = true;

        playerMovement.enabled = false;
        playerAttacking.enabled = false;

        Debug.Log("Player Dead");
    }
}
