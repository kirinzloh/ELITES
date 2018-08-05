using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GiganteController : MonoBehaviour
{
    public float moveSpeed;
    public string direction;
    
    public bool isAttacking;
    public bool isMoving;

    private Transform player;
    private Rigidbody2D giganteRigidbody;
    private SFXManager sfxMan;

    // Use this for initialization
    void Start()
    {
        player = PlayerManager.instance.player.transform;
        giganteRigidbody = GetComponent<Rigidbody2D>();
        sfxMan = FindObjectOfType<SFXManager>();

        isAttacking = false;
        isMoving = false;
        direction = "Left";
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttacking)
        {
            giganteRigidbody.velocity = new Vector3(0, 0, 0);
        }
        else
        {
            if (Vector3.Distance(transform.position, player.position) <= 10)
            {
                float xDiff = player.transform.position.x - transform.position.x;
                float yDiff = player.transform.position.y - transform.position.y;

                if (Mathf.Abs(xDiff) <= 0.9 && Mathf.Abs(yDiff) <= 0.4)
                {
                    isMoving = false;
                    giganteRigidbody.velocity = new Vector3(0, 0, 0);
                    isAttacking = true;
                    sfxMan.giganteFire.PlayDelayed(0.5f);
                    GetComponent<Animator>().SetBool("Attack", true);
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
        GetComponent<Animator>().SetBool("Attack", false);
        isAttacking = false;
    }

    void PlayDeathSound()
    {
        sfxMan.giganteDie.Play();
    }
}