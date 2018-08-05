﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaleMovement : MonoBehaviour {

    Animator animator;
    public float moveSpeed = 1f;
    //Cached components
    private Rigidbody2D rigidBody;
    private SpriteRenderer spriteRenderer;
    private Transform myTransform;


    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        {
            // float movex = Input.GetAxis ("Horizontal");
            // animator.SetFloat ("Speed", movex);
            // float movez = Input.GetAxis ("Vertical");
            // animator.SetFloat ("Speedz", movez);



        }
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Animating(h, v);

    }
    void Movement()
    {
<<<<<<< HEAD
<<<<<<< HEAD
        if (Input.GetKey(KeyCode.D))
=======
        if (Input.GetKey(KeyCode.RightArrow))
>>>>>>> parent of 62e1f2e... Merge branch 'Gale' into gamemap2
=======
        if (Input.GetKey(KeyCode.RightArrow))
>>>>>>> parent of da492af... commit
        {
            // rigidbody.AddForce(new Vector3 (1000.0f,0,0));
            rigidBody.MovePosition(transform.position + transform.right * moveSpeed * Time.deltaTime);
            // rigidBody.velocity = new Vector3 (moveSpeed, rigidBody.velocity.y, rigidBody.velocity.z);
            // myTransform.rotation = Quaternion.Euler (0, 0, 0);
            spriteRenderer.flipX = false;
            // animator.SetBool("walk", true);

            //transform.Translate(Vector3.right*0.75f*Time.deltaTime);
            // var ForwardBack = false;
            // transform.eulerAngles = new Vector3(0,0,0);
        }
<<<<<<< HEAD
<<<<<<< HEAD
        if (Input.GetKey(KeyCode.A))
=======
        if (Input.GetKey(KeyCode.LeftArrow))
>>>>>>> parent of 62e1f2e... Merge branch 'Gale' into gamemap2
=======
        if (Input.GetKey(KeyCode.LeftArrow))
>>>>>>> parent of da492af... commit
        {
            rigidBody.MovePosition(transform.position - transform.right * moveSpeed * Time.deltaTime);
            // rigidBody.velocity = new Vector3 (-moveSpeed, rigidBody.velocity.y, rigidBody.velocity.z);
            // myTransform.rotation = Quaternion.Euler (0, 0, 180);
            spriteRenderer.flipX = true;
            // animator.SetBool("walk", true);

            //transform.Translate(Vector3.left*0.75f*Time.deltaTime);
            // var ForwardBack = false;
            // transform.eulerAngles = new Vector3(0,0,0);
        }
<<<<<<< HEAD
<<<<<<< HEAD
        if (Input.GetKey(KeyCode.W))
=======
        if (Input.GetKey(KeyCode.UpArrow))
>>>>>>> parent of 62e1f2e... Merge branch 'Gale' into gamemap2
=======
        if (Input.GetKey(KeyCode.UpArrow))
>>>>>>> parent of da492af... commit
        {
            rigidBody.MovePosition(transform.position + transform.up * moveSpeed * Time.deltaTime);
            // animator.SetBool("walk", true);
            // rigidBody.velocity = new Vector3 (rigidBody.velocity.x, rigidBody.velocity.y, moveSpeed);
            // myTransform.rotation = Quaternion.Euler (0, 0, 0);

            //transform.Translate(Vector3.forward*0.75f*Time.deltaTime);
            // var ForwardBack = true;
            // transform.eulerAngles = new Vector3(0,0,0);
        }
<<<<<<< HEAD
<<<<<<< HEAD
        if (Input.GetKey(KeyCode.S))
=======
        if (Input.GetKey(KeyCode.DownArrow))
>>>>>>> parent of 62e1f2e... Merge branch 'Gale' into gamemap2
=======
        if (Input.GetKey(KeyCode.DownArrow))
>>>>>>> parent of da492af... commit
        {
            rigidBody.MovePosition(transform.position - transform.up * moveSpeed * Time.deltaTime);
            Debug.Log("forward");
            // animator.SetBool("walk", true);
            // rigidBody.velocity = new Vector3 (rigidBody.velocity.x, rigidBody.velocity.y, -moveSpeed);
            // myTransform.rotation = Quaternion.Euler (0, 180, 0);

            //transform.Translate(Vector3.back*0.75f*Time.deltaTime);
            // var ForwardBack = true;
            // transform.eulerAngles = new Vector3(0,0,0);
        }

    }

    private void Animating(float h, float v)
    {
        bool walk = h != 0f || v != 0f;
        animator.SetBool("walk", walk);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided");
        if (collision.gameObject.name == "Cube")  // or if(gameObject.CompareTag("YourWallTag"))
        {
            Debug.Log("Hit cube");
            rigidBody.velocity = Vector3.zero;

        }
    }

}
