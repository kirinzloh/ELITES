using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionelWeaponController : MonoBehaviour
{ 
    public int meleeDmg;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Deal damage
            other.GetComponent<PlayerHealthScript>().TakeDamage(meleeDmg);
        }
    }
}
