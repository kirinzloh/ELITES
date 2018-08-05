using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2DAdvanceAttackScript : MonoBehaviour
{

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
            timer = 0f;
        }
        else if (Input.GetButton("Fire2") && timer >= timeBetweenAttack && Time.timeScale != 0)
        {
            anim.SetTrigger("AttackRight");
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
