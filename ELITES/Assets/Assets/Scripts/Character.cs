using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    void OnMouseDown()
    {
        FindObjectOfType<DialogueTrigger>().TriggerDialogue();
    }

}
