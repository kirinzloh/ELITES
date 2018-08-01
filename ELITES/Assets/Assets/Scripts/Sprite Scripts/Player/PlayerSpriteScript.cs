using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteScript : MonoBehaviour {

    public Transform agent;
    public float yOffset;
    public float xOffset;

    Animator anim;
    Vector3 side;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void LateUpdate()
    {
        transform.localPosition = new Vector3(agent.localPosition.x + xOffset, agent.localPosition.z + yOffset, transform.localPosition.z);
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        //Move(h, v);
        Turning(h);
        Animating(h, v);
    }

    private void Turning(float h)
    {
        side = transform.localScale;
        if (h > 0)
        {
            side.x = Mathf.Abs(side.x);

        }
        else if (h < 0)
        {
            side.x = Mathf.Abs(side.x) * -1;
        }

        transform.localScale = side;
    }


    private void Animating(float h, float v)
    {
        bool walking = h != 0f || v != 0f;
        anim.SetBool("IsWalking", walking);
    }
}
