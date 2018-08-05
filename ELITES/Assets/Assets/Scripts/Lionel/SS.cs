using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SS : MonoBehaviour {
    private Animator ssAnim;
    private float ssTimeStamp;
    public int ssDmg;

    // Use this for initialization
    void Start ()
    {
        ssAnim = GetComponent<Animator>();
        ssTimeStamp = Time.time;
    }
	
	// Update is called once per frame
	void Update () {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerHealthScript>().TakeDamage(ssDmg);
        }
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
