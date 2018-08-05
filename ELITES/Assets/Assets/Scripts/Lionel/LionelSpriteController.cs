using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionelSpriteController : MonoBehaviour {
    private Animator anim;
    private GameObject parent;
    public GameObject ssPrefab;
    private Transform player;

    // Use this for initialization
    void Start ()
    {
        player = PlayerManager.instance.player.transform;
        anim = GetComponent<Animator>();
        parent = this.transform.parent.gameObject;
    }

    void jumpEnded()
    {
        parent.GetComponent<LionelController>().isJumping = false;
        anim.SetBool("Jump", false);
        anim.SetBool("Move", true);
    }

    public void attackEnded()
    {
        parent.GetComponent<LionelController>().isAttacking = false;
        anim.SetBool("Attack", false);
        anim.SetBool("Move", true);
    }

    void createSS()
    {
        GameObject SS = Instantiate(ssPrefab);
        SS.GetComponent<Transform>().position = new Vector3(player.transform.position.x, 0.1f, player.transform.position.z);
    }
}
