using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Singleton

    public static PlayerManager instance;
    public int questLevel = 0;
    public bool transitionAllowed = false;
    public GameObject player;


    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Update()
    {
        bool inCutscene = QuestManager.instance.inCutscene;
        bool inDialogue = DialogueManager.instance.inDialogue;
        if (inCutscene || inDialogue)
        {
            player.GetComponent<PlayerAttack>().enabled = false;
            player.GetComponent<PlayerMovement>().enabled = false;
        }
        else
        {
            player.GetComponent<PlayerAttack>().enabled = true;
            player.GetComponent<PlayerMovement>().enabled = true;
        }
    }

    #endregion

    public void QuestCompleted()
    {
        Debug.Log("Quest Complete");
        questLevel += 1;
        player.GetComponent<PlayerHealth>().currentHealth = player.GetComponent<PlayerHealth>().startingHealth;
        transitionAllowed = true;
    }

    public int getQuestLevel()
    {
        return questLevel;
    }

    public bool getTransitionPermission()
    {
        return transitionAllowed;
    }

    public void switchTransition()
    {
        transitionAllowed = false;
    }

    
}
