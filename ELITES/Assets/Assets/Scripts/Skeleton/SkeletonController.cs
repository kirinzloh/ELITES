using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonController : MonoBehaviour
{
    public float moveSpeed;
    public string direction;

    public bool isAttacking;
    public bool isMoving;

    private Transform player;
    private Rigidbody2D skeletonRigidbody;
    private SFXManager sfxMan;

    // Use this for initialization
    void Start()
    {
        player = PlayerManager.instance.player.transform;
        skeletonRigidbody = GetComponent<Rigidbody2D>();
        sfxMan = FindObjectOfType<SFXManager>();

        isAttacking = false;
        isMoving = false;

        direction = "Right";
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttacking)
        {
            skeletonRigidbody.velocity = new Vector3(0, 0, 0);
        }
        else
        {
            if (Vector3.Distance(transform.position, player.position) <= 10)
            {
                float xDiff = player.transform.position.x - transform.position.x;
                float yDiff = player.transform.position.y - transform.position.y;

                if (Mathf.Abs(xDiff) <= 0.5 && Mathf.Abs(yDiff) <= 0.1)
                {
                    isMoving = false;
                    skeletonRigidbody.velocity = new Vector3(0, 0, 0);
                    isAttacking = true;
                    sfxMan.skeletonAtt.PlayDelayed(0.5f);
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

    void PlayDeathSound()
    {
        sfxMan.skeletonDie.Play();
    }
}
