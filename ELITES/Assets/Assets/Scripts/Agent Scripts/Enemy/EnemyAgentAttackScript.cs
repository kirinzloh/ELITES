using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAgentAttackScript : MonoBehaviour {

    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;

    GameObject player;
    //Animator anim;
    PlayerAgentHealthScript playerHealth;
    //EnemyHealth enemyHealth;
    bool playerInRange;
    float timer;
    
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerAgentHealthScript>();
        //enemyHealth = GetComponent<EnemyHealth>();
        //anim = GetComponent<Animator>();
    }
	

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }


    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks && playerInRange /*&& enemyHealth.currentHealth > 0*/)
        {
            Attack();
        }

        //if (playerHealth.currentHealth <= 0)
        //{
        //    anim.SetTrigger("PlayerDead");
        //}
    }


    void Attack()
    {   
        timer = 0f;

        if (playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }
}
