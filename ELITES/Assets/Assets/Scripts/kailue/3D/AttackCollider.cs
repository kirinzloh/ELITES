using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour {

    public int attackDamage = 20;

    GameObject enemy;
    bool enemyInRange;

    // Use this for initialization
    void Start () {
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemyInRange = true;
            enemy = other.gameObject;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == enemy)
        {
            enemy = null;
            enemyInRange = false;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void Attack()
    {
        
        if (enemyInRange)
        {
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(attackDamage);
            }
        }
    }
}
