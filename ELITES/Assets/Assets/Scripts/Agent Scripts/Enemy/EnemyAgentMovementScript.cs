using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAgentMovementScript : MonoBehaviour {

    private NavMeshAgent agent;
    public Transform player;

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }
	
	// Update is called once per frame
	void Update () {
        agent.SetDestination(player.position);
    }

    public void SetSpeed(float speed)
    {
        agent.speed = speed;
    }
}
