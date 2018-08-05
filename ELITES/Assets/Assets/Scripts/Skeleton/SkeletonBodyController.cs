using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonBodyController : MonoBehaviour
{
    public int hitDmg;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.GetComponent<PlayerHealth>().TakeDamage(hitDmg);
        }
    }
}