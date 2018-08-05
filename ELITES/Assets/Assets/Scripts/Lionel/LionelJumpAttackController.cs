using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LionelJumpAttackController : MonoBehaviour {
    public Vector3 moveDirection;
    public float moveSpeed;

    private Animator lionelJumpProjectileAnim;
    private float lionelJumpProjectileTimeStamp;
    //private Rigidbody2D lionelJumpProjectileRigidbody;

    // Use this for initialization
    void Start () {
        lionelJumpProjectileAnim = GetComponent<Animator>();
        lionelJumpProjectileTimeStamp = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(moveDirection.z * moveSpeed * Time.deltaTime, 0, 0));
        //lionelJumpProjectileRigidbody.velocity = new Vector3(0, 0, moveDirection.z * moveSpeed);
        NavMeshHit hit;
        if (!NavMesh.SamplePosition(transform.position, out hit, 0.1f, NavMesh.AllAreas))
        {
            print("gone");
            Destroy(gameObject);
        }
        if (Time.time - lionelJumpProjectileTimeStamp > 2)
        {
            lionelJumpProjectileAnim.SetInteger("lionelJumpProjectileState", 2);
        }
	}

    void midStateLionelJumpProjectile ()
    {
        lionelJumpProjectileAnim.SetInteger("lionelJumpProjectileState", 1);
    }

    void destroyLionelJumpProjectile ()
    {
        Destroy(gameObject);
    }
}
