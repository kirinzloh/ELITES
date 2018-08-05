using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int startingHealth = 100;
    public int currentHealth;
    //public Image damageImage;
    //public float flashSpeed = 5f;
    //public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    //Animator anim;
    PlayerMovement playerMovement;
    PlayerAttack playerAttacking;
    bool isDead;
    //bool damaged;

    private SFXManager sfxMan;


    void Start()
    {
        //anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        playerAttacking = GetComponent<PlayerAttack>();
        currentHealth = startingHealth;
        sfxMan = FindObjectOfType<SFXManager>();
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
        else
        {
            sfxMan.playerDamaged.Play();
        }
    }


    void Death()
    {
        isDead = true;

        playerMovement.enabled = false;
        playerAttacking.enabled = false;
        Destroy(gameObject, 2f);
        Debug.Log("Player Dead");
    }
}
