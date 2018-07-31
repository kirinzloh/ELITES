using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {

    // private UnityEngine.Tilemaps.TilemapRenderer tiler;
    Animation anim;
    //var animationSwitch : boolean = false;
    //var animateobject: GameObject;
    
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animation>();
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided");
        if (collision.gameObject.tag == "Player")  // or if(gameObject.CompareTag("YourWallTag"))
        {
            //Object.Destroy(tiler);
            //animationSwitch = true;
            //animateobject.animation.CrossFade("dooropen");
            Debug.Log("Open Door");
            //anim.Play("dooropen");
            //if (!anim.isPlaying)
            //{
            //    Debug.Log("hi");
            //    anim.Play("dooropen");
            //}
            PlayAnimation("dooropen");

        }
    }
    void PlayAnimation(string AnimName)
    {
        if (!anim.IsPlaying(AnimName))
        {
            anim.CrossFadeQueued(AnimName, 0.3f, QueueMode.PlayNow);
            Debug.Log("crossfade");
        }
    }
}
