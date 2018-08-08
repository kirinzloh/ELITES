using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private float currentEnergy = 100;

    [SerializeField]
    private Image hpBar;
    [SerializeField]
    private Image energyBar;
    private float maxEnergy = 100;

    public int startingHealth = 100;
    public int currentHealth;
    //public Image damageImage;
    //public float flashSpeed = 5f;
    //public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    //Animator anim;
    PlayerMovement playerMovement;
    PlayerAttack playerAttacking;
    public bool isDead;
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
        HandleBar();
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
        //Destroy(gameObject, 2f);
        Debug.Log("Player Dead");
    }

    private void HandleBar()
    {
        hpBar.fillAmount = Map(currentHealth, startingHealth);
        energyBar.fillAmount = Map(currentEnergy, maxEnergy);
    }

    private float Map(float current, float max)
    {
        return (current / max);
    }
}
