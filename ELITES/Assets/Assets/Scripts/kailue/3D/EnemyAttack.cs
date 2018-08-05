using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;

    public GameObject player;
    //Animator anim;
    PlayerHealthScript playerHealth;
    //EnemyHealth enemyHealth;
    bool playerInRange;
    float timer;

    void Start()
    {
        playerHealth = player.GetComponent<PlayerHealthScript>();
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
        //Debug.Log(playerInRange);
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
