using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour {
    
    private float movementSpeed = 2f;

    AudioSource footstep;
   

    Transform sprite;
    Vector3 movement;
    Animator anim;
    Vector3 side;


    void Start () {
        sprite = transform.GetChild(0);
        sprite.Rotate(90, 0, 0);

        footstep = this.GetComponent<AudioSource>();
        anim = sprite.GetComponent<Animator>();
        
	}

	
	void Update () {
		
	}


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
        movement.Set(h, 0, v);
        movement = movement.normalized * movementSpeed * Time.deltaTime;

        transform.Translate(movement);
    }

    private void Turning(float h)
    {
        side = sprite.localScale;
        if (h > 0)
        {
            side.x = Mathf.Abs(side.x);

        }
        else if (h < 0)
        {
            side.x = Mathf.Abs(side.x) * -1;
        }

        sprite.localScale = side;
    }


    private void Animating(float h, float v)
    {
        bool walking = h != 0f || v != 0f;
        anim.SetBool("IsWalking", walking);
        if (walking == true)
        {
            footstep.Play();
        }
        else
        {
            footstep.Stop();
        }
    }
}
