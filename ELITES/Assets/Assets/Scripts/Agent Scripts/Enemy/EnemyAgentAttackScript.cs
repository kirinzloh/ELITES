using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAgentAttackScript : MonoBehaviour {

    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;
    public Transform player;

    //GameObject player;
    //Animator anim;
    //PlayerHealth playerHealth;
    //EnemyHealth enemyHealth;
    bool playerInRange;
    float timer;
    
    void Start () {
        //player = GameObject.FindGameObjectWithTag("Player");
        //playerHealth = player.GetComponent<PlayerHealth>();
        //enemyHealth = GetComponent<EnemyHealth>();
        //anim = GetComponent<Animator>();
    }
	

    void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            playerInRange = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            playerInRange = false;
            Debug.Log("player left");
        }
    }


    void Update()
    {
        Debug.Log(playerInRange);
        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks && playerInRange/* && enemyHealth.currentHealth > 0*/)
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

        Debug.Log("Player Attacked");

        //if (playerHealth.currentHealth > 0)
        //{
        //    playerHealth.TakeDamage(attackDamage);
        //}
    }
}
