using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteAttackScript : MonoBehaviour {

    private float attackDamage = 20f;
    private float timeBetweenAttack = 0.50f;
    public Transform attackPoint;
    public LayerMask layerAttack;
    public float attackRange;

    Animator anim;
    float timer;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if ((Input.GetButton("Fire1") || Input.GetButton("Fire2"))/* && timer >= timeBetweenAttack && Time.timeScale != 0*/)
        {
            anim.SetTrigger("Attack");
            Attack();
        }
    }

    private void Attack()
    {
        timer = 0f;

        //gunAudio.Play();


        //gunParticles.Stop();
        //gunParticles.Play();


        Collider2D[] enemyInRange = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, layerAttack);
        for (int i = 0; i < enemyInRange.Length; i++)
        {
            //enemyInRange[i].GetComponent<EnemyHealth>().TakeDamage(attackDamage);
            Debug.Log("enemy damaged");
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
