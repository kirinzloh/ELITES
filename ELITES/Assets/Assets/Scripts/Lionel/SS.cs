using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SS : MonoBehaviour {
    private Animator ssAnim;
    private float ssTimeStamp;
    private bool hit;
    private Transform player;

    // Use this for initialization
    void Start ()
    {
        player = PlayerManager.instance.player.transform;
        ssAnim = GetComponent<Animator>();
        ssTimeStamp = Time.time;
        hit = false;
    }
	
	// Update is called once per frame
	void Update () {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Deal damage
            print("hit");
        }
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
