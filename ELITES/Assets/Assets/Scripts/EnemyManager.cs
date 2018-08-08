using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public static EnemyManager instance;

    public GameObject player;
    private Transform attackPoint;
    private LayerMask layerAttack;
    private float attackRange;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            attackPoint = player.GetComponent<PlayerAttack>().attackPoint;
            layerAttack = player.GetComponent<PlayerAttack>().layerAttack;
            attackRange = player.GetComponent<PlayerAttack>().attackRange;
        }
    }

    void Update()
    {
        if (PlayerManager.instance.getQuestLevel() == 4)
        {
            Collider2D[] enemyInRange = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, layerAttack);
            for (int i = 0; i < enemyInRange.Length; i++)
            {
                Debug.Log("Enemy Health: " + enemyInRange[i].transform.parent.GetComponent<EnemyHealthController>().health);
                if (enemyInRange[i].transform.parent.GetComponent<EnemyHealthController>().health <= 0)
                {
                    Debug.Log("Quest enemy killed");
                }
            }
        }
    }
}
