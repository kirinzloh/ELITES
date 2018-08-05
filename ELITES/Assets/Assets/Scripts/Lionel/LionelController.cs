using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LionelController : MonoBehaviour {
    public float moveSpeed;
    public string direction;
    public int health;
    public int jumpCD;
    public int mirrorImageCD;
    public bool clone;

    public bool isJumping;
    public bool isAttacking;
    public bool isMoving;
    private int jumpProc;
    private int mirrorImageProc;
    private float jumpTimeStamp;
    private float mirrorImageTimeStamp;

    public GameObject lionelPrefab;

    private Transform player;
    public NavMeshAgent agent;
    private Transform lionelSprite;

    // Use this for initialization
    void Start () {
        player = PlayerManager.instance.player.transform;

        agent = GetComponent<NavMeshAgent>();
        agent.speed = moveSpeed;

        isJumping = false;
        isAttacking = false;
        isMoving = false;

        jumpProc = Random.Range(0, 200);
        mirrorImageProc = Random.Range(0, 450);

        jumpTimeStamp = 0;
        mirrorImageTimeStamp = 0;
        direction = "Right";

        if (clone)
        {
            Destroy(gameObject, 5);
        }

        foreach (Transform child in transform)
        {
            lionelSprite = child;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 angle = new Vector3(90, 0, 0);
        lionelSprite.transform.eulerAngles = new Vector3(90, 0, 0);
        if (isJumping)
        {
            agent.speed = 0;
        }
        else if (isAttacking)
        {
            agent.speed = 0;
        }
        else
        {
            isMoving = false;
            if (Vector3.Distance(transform.position, player.position) >= 0.5 && !clone && Random.Range(0, 450) == mirrorImageProc && mirrorImageTimeStamp <= Time.time)
            {
                agent.speed = 0;
                mirrorImageTimeStamp = Time.time + mirrorImageCD;
                List<Vector3> mirrorImagesPositions = new List<Vector3>();
                Vector3 position1 = transform.position;
                Vector3 position2 = new Vector3(transform.position.x + Random.Range(-1.5f, 1.5f), transform.position.y, transform.position.z + Random.Range(-1.5f, 1.5f));
                NavMeshHit hit;
                if (NavMesh.SamplePosition(position2, out hit, 5, 1))
                {
                    position2 = hit.position;
                }
                Vector3 position3 = new Vector3(transform.position.x + Random.Range(-1.5f, 1.5f), transform.position.y, transform.position.z + Random.Range(-1.5f, 1.5f));
                if (NavMesh.SamplePosition(position3, out hit, 5, 1))
                {
                    position3 = hit.position;
                }
                while (Vector3.Distance(position2, player.position) <= 0.5f && Vector3.Distance(position2, position1) <= 0.5f)
                {
                    position2 = new Vector3(transform.position.x + Random.Range(-1.5f, 1.5f), transform.position.y, transform.position.z + Random.Range(-1.5f, 1.5f));
                    if (NavMesh.SamplePosition(position2, out hit, 5, 1))
                    {
                        position2 = hit.position;
                    }
                }

                while (Vector3.Distance(position3, player.position) <= 0.5f && Vector3.Distance(position3, position1) <= 0.5f && Vector3.Distance(position3, position2) <= 0.5f)
                {
                    position3 = new Vector3(transform.position.x + Random.Range(-1.5f, 1.5f), transform.position.y, transform.position.z + Random.Range(-1.5f, 1.5f));
                    if (NavMesh.SamplePosition(position3, out hit, 5, 1))
                    {
                        position3 = hit.position;
                    }
                }

                mirrorImagesPositions.Add(position1);
                mirrorImagesPositions.Add(position2);
                mirrorImagesPositions.Add(position3);

                int randomPosition = Random.Range(0, 2);
                GameObject image1 = Instantiate(lionelPrefab);
                image1.GetComponent<Transform>().position = new Vector3(mirrorImagesPositions[randomPosition].x, transform.position.y, mirrorImagesPositions[randomPosition].z);
                image1.GetComponent<LionelController>().player = player;
                image1.GetComponent<LionelController>().clone = true;
                mirrorImagesPositions.RemoveAt(randomPosition);

                randomPosition = Random.Range(0, 1);
                GameObject image2 = Instantiate(lionelPrefab);
                image2.GetComponent<Transform>().position = new Vector3(mirrorImagesPositions[randomPosition].x, transform.position.y, mirrorImagesPositions[randomPosition].z);
                image2.GetComponent<LionelController>().player = player;
                image2.GetComponent<LionelController>().clone = true;
                mirrorImagesPositions.RemoveAt(randomPosition);

                transform.position = new Vector3(mirrorImagesPositions[0].x, transform.position.y, mirrorImagesPositions[0].z);
            }
            else if (Vector3.Distance(transform.position, player.position) <= 10)
            {
                if (Vector3.Distance(transform.position, player.position) <= 3 && Random.Range(0, 200) == jumpProc && jumpTimeStamp <= Time.time && !clone)
                {
                    agent.speed = 0;
                    jumpTimeStamp = Time.time + jumpCD;
                    isMoving = false;
                    lionelSprite.GetComponent<Animator>().SetBool("Move", isMoving);
                    isJumping = true;
                    lionelSprite.GetComponent<Animator>().SetBool("Jump", isJumping);
                }
                else
                {
                    float xDiff = player.transform.position.x - transform.position.x;
                    float zDiff = player.transform.position.z - transform.position.z;

                    if (Mathf.Abs(xDiff) <= 0.35 && Mathf.Abs(zDiff) <= 0.05)
                    {
                        isMoving = false;
                        agent.speed = 0;
                        isAttacking = true;
                        lionelSprite.GetComponent<Animator>().SetBool("Move", false);
                        lionelSprite.GetComponent<Animator>().SetBool("Attack", true);
                    }
                    else
                    {
                        if (direction == "Left" && agent.velocity.x > 0)
                        {
                            direction = "Right";
                            UpdateDirection(direction);
                        }
                        else if (direction == "Right" && agent.velocity.x < 0)
                        {
                            direction = "Left";
                            UpdateDirection(direction);
                        }

                        if (isMoving == false)
                        {
                            isMoving = true;
                            lionelSprite.GetComponent<Animator>().SetBool("Move", true);
                            agent.speed = 1f;
                        }
                        agent.SetDestination(player.position);
                    }
                }
            }
        }
    }

    void UpdateDirection(string direction)
    {
        Transform c = lionelSprite;
        foreach (Transform child in lionelSprite.transform)
        {
            c = child;
        }

        if (direction == "Right")
        {
            c.transform.Rotate(new Vector3(0, -180, 0), Space.Self);

        }
        else if (direction == "Left")
        {
            c.transform.Rotate(new Vector3(0, 180, 0), Space.Self);
        }
        lionelSprite.GetComponent<SpriteRenderer>().flipX = !lionelSprite.GetComponent<SpriteRenderer>().flipX;
    }
}   