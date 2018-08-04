using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public Dialogue dialogue;

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Triggered dialogue");
            DialogueManager.Instance.StartDialogue(dialogue);
        }
    }

}
