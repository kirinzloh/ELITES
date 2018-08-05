using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2DAdvanceAttackScript : MonoBehaviour
{
    
    public Transform attackPoint;
    public LayerMask layerAttack;
    public float attackRange;
    public int attackDamage;
    private float timeBetweenAttack = 0.50f;

    Animator anim;
    float timer;

    void Start()
    {
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetButton("Fire1") && timer >= timeBetweenAttack && Time.timeScale != 0)
        {
            anim.SetTrigger("AttackLeft");
            Attack();
        }
        else if (Input.GetButton("Fire2") && timer >= timeBetweenAttack && Time.timeScale != 0)
        {
            anim.SetTrigger("AttackRight");
            Attack();
        }
        else if (Input.GetKeyDown(KeyCode.Q) && timer >= timeBetweenAttack && Time.timeScale != 0)
        {
            anim.SetTrigger("TrueStrike");
            Attack();
        }
        else if (Input.GetKeyDown(KeyCode.E) && timer >= timeBetweenAttack && Time.timeScale != 0)
        {
            anim.SetTrigger("Cleave");
            Attack();
        }
        else if (Input.GetKeyDown(KeyCode.R) && timer >= timeBetweenAttack && Time.timeScale != 0)
        {
            anim.SetTrigger("Stun");
            Attack();
        }
        else if (Input.GetKeyDown(KeyCode.F) && timer >= timeBetweenAttack && Time.timeScale != 0)
        {
            //anim.SetTrigger("HyperSpeed");
            Attack();
        }
    }

    private void Attack()
    {
        timer = 0f;

        Collider2D[] enemyInRange = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, layerAttack);
        for (int i = 0; i < enemyInRange.Length; i++)
        {
            enemyInRange[i].GetComponent<EnemyHealth>().TakeDamage(attackDamage);
            Debug.Log("enemy damaged");
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
