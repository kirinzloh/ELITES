using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2DBasicAttackScript : MonoBehaviour {

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

        if ((Input.GetButton("Fire1") || Input.GetButton("Fire2")) && timer >= timeBetweenAttack && Time.timeScale != 0)
        {
            anim.SetTrigger("Attack");
            timer = 0f;
        }
    }
}
