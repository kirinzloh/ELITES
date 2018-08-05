using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAdvanceAttackScript : MonoBehaviour {

    private float timeBetweenAttack = 0.50f;

    Animator anim;
    AttackCollider attack;
    float timer;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        attack = GetComponentInChildren<AttackCollider>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetButton("Fire1") && timer >= timeBetweenAttack && Time.timeScale != 0)
        {
            anim.SetTrigger("AttackLeft");
            attack.Attack();
            timer = 0f;
        }
        else if (Input.GetButton("Fire2") && timer >= timeBetweenAttack && Time.timeScale != 0)
        {
            anim.SetTrigger("AttackRight");
            attack.Attack();
            timer = 0f;
        }
        else if (Input.GetKeyDown(KeyCode.Q) && timer >= timeBetweenAttack && Time.timeScale != 0)
        {
            anim.SetTrigger("TrueStrike");
            timer = 0f;
        }
        else if (Input.GetKeyDown(KeyCode.E) && timer >= timeBetweenAttack && Time.timeScale != 0)
        {
            anim.SetTrigger("Cleave");
            timer = 0f;
        }
        else if (Input.GetKeyDown(KeyCode.R) && timer >= timeBetweenAttack && Time.timeScale != 0)
        {
            anim.SetTrigger("Stun");
            timer = 0f;
        }
        else if (Input.GetKeyDown(KeyCode.F) && timer >= timeBetweenAttack && Time.timeScale != 0)
        {
            //anim.SetTrigger("HyperSpeed");
            timer = 0f;
        }
    }
}
