using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteAttackScript : MonoBehaviour {
    private float timeBetweenAttack = 0.50f;

    Animator anim;
    float timer;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if ((Input.GetButton("Fire1") || Input.GetButton("Fire2")) && timer >= timeBetweenAttack && Time.timeScale != 0)
        {
            anim.SetTrigger("Attack");
            timer = 0f;
        }
    }
}
