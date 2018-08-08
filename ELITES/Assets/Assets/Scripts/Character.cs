using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour {

    public Dialogue dialogue;
    public Quest quest;
    public Animator animator;
    public int stage;
    public bool isQuest;

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isQuest == false)
            {
                Debug.Log("Triggered dialogue");
                DialogueManager.instance.StartDialogue(dialogue);
            }
            else
            {
                int questLevel = PlayerManager.instance.getQuestLevel();
                if (questLevel == 1 || questLevel == 4)
                {
                    DialogueManager.instance.StartDialogue(dialogue);
                }
            }
        }
    }

    void Update()
    {
        if (PlayerManager.instance.getQuestLevel() == 1 && QuestManager.instance.dialogueEnded && isQuest)
        {
            QuestManager.instance.currentQuest.isCompleted = true;
            animator.SetInteger("stage", stage);
            QuestManager.instance.dialogueEnded = false;
        }
        if (PlayerManager.instance.getQuestLevel() == 4 && QuestManager.instance.dialogueEnded && isQuest)
        {
            animator.SetInteger("stage", stage);
            QuestManager.instance.dialogueEnded = false;
        }
    }

}
