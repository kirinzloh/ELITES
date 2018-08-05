using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LionelController : MonoBehaviour {
    public float moveSpeed;
    public string direction;
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
    public GameObject ssPrefab;

    private Transform player;
    private Rigidbody2D lionelRigidbody;
    private SFXManager sfxMan;

    // Use this for initialization
    void Start () {
        player = PlayerManager.instance.player.transform;
        lionelRigidbody = GetComponent<Rigidbody2D>();
        sfxMan = FindObjectOfType<SFXManager>();

        isJumping = false;
        isAttacking = false;
        isMoving = false;

        jumpProc = Random.Range(0, 200);
        mirrorImageProc = Random.Range(0, 450);

        jumpTimeStamp = 0;
        mirrorImageTimeStamp = 0;
        direction = "Right";
        Vector3 initialScale = transform.localScale;
        initialScale.x = Mathf.Abs(initialScale.x);
        transform.localScale = initialScale;

        if (clone)
        {
            Destroy(gameObject, 5);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (isJumping)
        {
            lionelRigidbody.velocity = new Vector3(0, 0, 0);
        }
        else if (isAttacking)
        {
            lionelRigidbody.velocity = new Vector3(0, 0, 0);
        }
        else
        {
            isMoving = false;
            GetComponent<Animator>().SetBool("Move", isMoving);
            if (Vector3.Distance(transform.position, player.position) >= 0.5 && !clone && Random.Range(0, 450) == mirrorImageProc && mirrorImageTimeStamp <= Time.time)
            {
                lionelRigidbody.velocity = new Vector3(0, 0, 0);
                mirrorImageTimeStamp = Time.time + mirrorImageCD;
                List<Vector3> mirrorImagesPositions = new List<Vector3>();
                Vector3 position1 = transform.position;
                Vector3 position2 = new Vector3(transform.position.x + Random.Range(-1.5f, 1.5f), transform.position.y + Random.Range(-1.5f, 1.5f), transform.position.z);
                Vector3 position3 = new Vector3(transform.position.x + Random.Range(-1.5f, 1.5f), transform.position.y + Random.Range(-1.5f, 1.5f), transform.position.z);
                while (Vector3.Distance(position2, player.position) <= 0.5f && Vector3.Distance(position2, position1) <= 0.5f)
                {
                    position2 = new Vector3(transform.position.x + Random.Range(-1.5f, 1.5f), transform.position.y + Random.Range(-1.5f, 1.5f), transform.position.z);
                }
                while (Vector3.Distance(position3, player.position) <= 0.5f && Vector3.Distance(position3, position1) <= 0.5f && Vector3.Distance(position3, position2) <= 0.5f)
                {
                    position3 = new Vector3(transform.position.x + Random.Range(-1.5f, 1.5f), transform.position.y + Random.Range(-1.5f, 1.5f), transform.position.z);
                }

                mirrorImagesPositions.Add(position1);
                mirrorImagesPositions.Add(position2);
                mirrorImagesPositions.Add(position3);

                sfxMan.lionelClone.Play();
                int randomPosition = Random.Range(0, 2);
                GameObject image1 = Instantiate(lionelPrefab);
                image1.GetComponent<Transform>().position = new Vector3(mirrorImagesPositions[randomPosition].x, mirrorImagesPositions[randomPosition].y, transform.position.z);
                image1.GetComponent<LionelController>().player = player;
                image1.GetComponent<LionelController>().clone = true;
                mirrorImagesPositions.RemoveAt(randomPosition);

                randomPosition = Random.Range(0, 1);
                GameObject image2 = Instantiate(lionelPrefab);
                image2.GetComponent<Transform>().position = new Vector3(mirrorImagesPositions[randomPosition].x, mirrorImagesPositions[randomPosition].y, transform.position.z);
                image2.GetComponent<LionelController>().player = player;
                image2.GetComponent<LionelController>().clone = true;
                mirrorImagesPositions.RemoveAt(randomPosition);

                transform.position = new Vector3(mirrorImagesPositions[0].x, mirrorImagesPositions[0].y, transform.position.z);
            }
            else if (Vector3.Distance(transform.position, player.position) <= 10)
            {
                if (Vector3.Distance(transform.position, player.position) <= 3 && Random.Range(0, 200) == jumpProc && jumpTimeStamp <= Time.time && !clone)
                {
                    lionelRigidbody.velocity = new Vector3(0, 0, 0);
                    jumpTimeStamp = Time.time + jumpCD;
                    sfxMan.lionelBomb.Play();
                    isMoving = false;
                    GetComponent<Animator>().SetBool("Move", isMoving);
                    isJumping = true;
                    GetComponent<Animator>().SetBool("Jump", isJumping);
                }
                else
                {
                    float xDiff = player.transform.position.x - transform.position.x;
                    float yDiff = player.transform.position.y - transform.position.y;

                    if (Mathf.Abs(xDiff) <= 0.5 && Mathf.Abs(yDiff) <= 0.2)
                    {
                        isMoving = false;
                        lionelRigidbody.velocity = new Vector3(0, 0, 0);
                        isAttacking = true;
                        sfxMan.lionelAtt.Play();
                        GetComponent<Animator>().SetBool("Attack", isAttacking);
                        GetComponent<Animator>().SetBool("Move", isMoving);
                    }
                    else
                    {
                        if (direction == "Left" && xDiff > 0.05)
                        {
                            direction = "Right";
                            UpdateDirection();
                        }
                        else if (direction == "Right" && xDiff < -0.05)
                        {
                            direction = "Left";
                            UpdateDirection();
                        }
                        isMoving = true;
                        GetComponent<Animator>().SetBool("Move", isMoving);
                        transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed);
                    }
                }
            }
        }
    }

    void UpdateDirection()
    {
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }

    void AttackEnded()
    {
        isAttacking = false;
        GetComponent<Animator>().SetBool("Attack", isAttacking);
    }

    void JumpEnded()
    {
        isJumping = false;
        GetComponent<Animator>().SetBool("Jump", isJumping);
    }

    void createSS()
    {
        GameObject ss = Instantiate(ssPrefab);
        ss.GetComponent<Transform>().position = new Vector3(player.position.x, player.position.y, player.position.z);
    }

    void PlayDeathSound()
    {
        sfxMan.lionelDie.Play();
    }
}   