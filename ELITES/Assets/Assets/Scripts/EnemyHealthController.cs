using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyHealthController : MonoBehaviour {
    public int health;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            GetComponent<Animator>().SetBool("Dead", true);
        }
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
