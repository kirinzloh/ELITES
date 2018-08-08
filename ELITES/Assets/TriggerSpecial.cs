using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpecial : MonoBehaviour {

    public Animator animator1;
    public Animator animator2;
    public Dialogue dialogue1;
    public Dialogue dialogue2;

    private bool startedDialogue;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (PlayerManager.instance.getQuestLevel() == 13)
        {
            DialogueManager.instance.StartDialogue(dialogue1);
        }
    }

    void Update()
    {
        if (QuestManager.instance.dialogueEnded && PlayerManager.instance.getQuestLevel() == 13)
        {
            animator1.SetInteger("stage", 3);
            QuestManager.instance.dialogueEnded = false;
            PlayerManager.instance.questLevel += 1;
        }
        if (PlayerManager.instance.getQuestLevel() == 14 && startedDialogue == false)
        {
            startedDialogue = true;
            DialogueManager.instance.StartDialogue(dialogue2);
        }
        if (QuestManager.instance.dialogueEnded && PlayerManager.instance.getQuestLevel() == 14)
        {
            animator2.SetBool("lionel_attack", true);
            animator1.SetInteger("stage", 4);
            QuestManager.instance.dialogueEnded = false;
            PlayerManager.instance.questLevel += 1;
        }
    }

}
