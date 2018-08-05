using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAgentAttackScript : MonoBehaviour {

    public float timeBetweenAttacks = 0.5f;
    public float attackRange;
    public int attackDamage = 20;
    
    GameObject enemy;
    //RaycastHit hit;
    bool enemyInRange;
    float timer;
    int side = 1;


    Ray shootRay = new Ray();
    RaycastHit attackHit;
    int enemyMask;

    void Start()
    {
        enemyMask = LayerMask.GetMask("Enemy");
        //playerHealth = GetComponent<PlayerAgentHealthScript>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == enemy)
        {
            enemyInRange = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == enemy)
        {
            enemyInRange = false;
        }
    }


    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        Direction(h);

        timer += Time.deltaTime;

        if ((Input.GetButton("Fire1") || Input.GetButton("Fire2")) && timer >= timeBetweenAttacks && Time.timeScale != 0)
        {
            Attack();
        }
    }


    void Attack()
    {
        timer = 0f;

        shootRay.origin = transform.position;
        shootRay.direction = new Vector3(side, 0, 0);

        if (Physics.Raycast(shootRay, out attackHit, attackRange, enemyMask))
        {
            EnemyAgentHealthScript enemyHealth = attackHit.collider.GetComponent<EnemyAgentHealthScript>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(attackDamage);
            }
        }
    }

    private void Direction(float h)
    {
        if (h > 0)
        {
            side = 1;

        }
        else if (h < 0)
        {
            side = -1;
        }
        
    }
}
