using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAgentMovementScript : MonoBehaviour {

    //private NavMeshAgent agent;
    private float movementSpeed = 2f;

    Vector3 movement;

    void Start () {
        //agent = GetComponent<NavMeshAgent>();
        
    }

	
	void Update () {
		
	}


    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);
        //Turning(h);
        //Animating(h, v);
    }


    private void Move(float h, float v)
    {
        movement.Set(h, 0, v);

        movement = movement.normalized * movementSpeed * Time.deltaTime;

        transform.Translate(movement);
    }

    //private void Turning(float h)
    //{
    //    side = transform.localScale;
    //    if (h > 0)
    //    {
    //        side.x = Mathf.Abs(side.x);

    //    }
    //    else if (h < 0)
    //    {
    //        side.x = Mathf.Abs(side.x) * -1;
    //    }

    //    transform.localScale = side;
    //}


    //private void Animating(float h, float v)
    //{
    //    bool walking = h != 0f || v != 0f;
    //    anim.SetBool("IsWalking", walking);
    //}

}
