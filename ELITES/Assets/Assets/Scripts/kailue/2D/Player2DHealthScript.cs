using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2DHealthScript : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;
    //public Image damageImage;
    //public float flashSpeed = 5f;
    //public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    //Animator anim;
    Player2DMovementScript playerMovement;
    Player2DAttackScript playerAttacking;
    bool isDead;
    //bool damaged;


    void Start()
    {
        //anim = GetComponent<Animator>();
        playerMovement = GetComponent<Player2DMovementScript>();
        playerAttacking = GetComponent<Player2DAttackScript>();
        currentHealth = startingHealth;
    }


    void Update()
    {
        //if (damaged)
        //{
        //    damageImage.color = flashColour;
        //}
        //else
        //{
        //    damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        //}
        //damaged = false;
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
