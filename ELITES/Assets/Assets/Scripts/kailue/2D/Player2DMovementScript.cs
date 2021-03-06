﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2DMovementScript : MonoBehaviour {

    private float movementSpeed = 2f;

    AudioSource footstep;
    Vector3 movement;
    Animator anim;
    Vector3 side;

    bool f_Play = false;


    void Start()
    {
        footstep = this.GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        //bool f_Play = false;
    }


    /*void Update()
    {
        if (f_Play==true && !footstep.isPlaying)
        {
            footstep.Play();
        }
        else
        {
            footstep.Stop();
        }
        
    }*/


    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);
        Turning(h);
        Animating(h, v);
    }


    private void Move(float h, float v)
    {
        movement.Set(h, v, 0);
        movement = movement.normalized * movementSpeed * Time.deltaTime;

        transform.Translate(movement);
    }

    private void Turning(float h)
    {
        side = transform.localScale;
        if (h > 0)
        {
            side.x = Mathf.Abs(side.x);

        }
        else if (h < 0)
        {
            side.x = Mathf.Abs(side.x) * -1;
        }

        transform.localScale = side;
    }


    private void Animating(float h, float v)
    {
        bool walking = h != 0f || v != 0f;
        anim.SetBool("IsWalking", walking);
        if (walking == true)
        {
            f_Play = true;
        }
        else
        {
            f_Play = false;
        }
    }
}
