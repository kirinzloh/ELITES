﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int attackDamage;
    public float timeBetweenAttack;
    public int trueStrikeDamage;
    public float trueStrikeRange;
    public float trueStrikeCD;
    public int cleaveDamage;
    public float cleaveCD;
    public int stunDamage;
    public float stunCD;
    public float hyperspeedCD;
    public Transform attackPoint;
    public LayerMask layerAttack;
    public float attackRange;
    

    Animator anim;
    float attackTimer;
    float trueStrikeTimer;
    float cleaveTimer;
    float stunTimer;
    float hyperspeedTimer;

    void Start()
    {
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        attackTimer += Time.deltaTime;
        trueStrikeTimer += Time.deltaTime;
        cleaveTimer += Time.deltaTime;
        stunTimer += Time.deltaTime;
        hyperspeedTimer += Time.deltaTime;

        if (Input.GetButton("Fire1") && attackTimer >= timeBetweenAttack && Time.timeScale != 0)
        {
            anim.SetTrigger("AttackLeft");
            BasicAttack();
        }
        else if (Input.GetButton("Fire2") && attackTimer >= timeBetweenAttack && Time.timeScale != 0)
        {
            anim.SetTrigger("AttackRight");
            BasicAttack();
        }
        else if (Input.GetKeyDown(KeyCode.Q) && trueStrikeTimer >= trueStrikeCD && Time.timeScale != 0)
        {
            anim.SetTrigger("TrueStrike");
            TrueStrike();
        }
        else if (Input.GetKeyDown(KeyCode.E) && cleaveTimer >= cleaveCD && Time.timeScale != 0)
        {
            anim.SetTrigger("Cleave");
            Cleave();
        }
        else if (Input.GetKeyDown(KeyCode.R) && stunTimer >= stunCD && Time.timeScale != 0)
        {
            anim.SetTrigger("Stun");
            Stun();
        }
        else if (Input.GetKeyDown(KeyCode.F) && hyperspeedTimer >= hyperspeedCD && Time.timeScale != 0)
        {
            //anim.SetTrigger("HyperSpeed");
            //Attack();
        }
    }

    private void BasicAttack()
    {
        attackTimer = 0f;

        Collider2D[] enemyInRange = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, layerAttack);
        for(int i = 0; i < enemyInRange.Length; i++)
        {
            enemyInRange[i].GetComponent<EnemyHealth>().TakeDamage(attackDamage);
            Debug.Log("enemy damaged");
            break;
        }

    }

    private void TrueStrike()
    {
        trueStrikeTimer = 0f;

        Collider2D[] enemyInRange = Physics2D.OverlapCircleAll(attackPoint.position, trueStrikeRange, layerAttack);
        for (int i = 0; i < enemyInRange.Length; i++)
        {
            enemyInRange[i].GetComponent<EnemyHealth>().TakeDamage(trueStrikeDamage);
            Debug.Log("enemy damaged");
        }

    }

    private void Cleave()
    {
        cleaveTimer = 0f;

        Collider2D[] enemyInRange = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, layerAttack);
        for (int i = 0; i < enemyInRange.Length; i++)
        {
            enemyInRange[i].GetComponent<EnemyHealth>().TakeDamage(cleaveDamage);
            Debug.Log("enemy damaged");
        }

    }
    private void Stun()
    {
        stunTimer = 0f;

        Collider2D[] enemyInRange = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, layerAttack);
        for (int i = 0; i < enemyInRange.Length; i++)
        {
            enemyInRange[i].GetComponent<EnemyHealth>().TakeDamage(stunDamage);
            Debug.Log("enemy damaged");
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}