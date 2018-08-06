using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Singleton

    public static PlayerManager instance;
    public int questLevel = 0;
    public bool transitionAllowed = false;

    void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            QuestCompleted();
        }
    }

    #endregion

    public GameObject player;

    public void QuestCompleted()
    {
        questLevel += 1;
        player.GetComponent<PlayerHealth>().currentHealth = player.GetComponent<PlayerHealth>().startingHealth;
        if (questLevel >= 1)
        {
            player.GetComponent<PlayerAttack>().enabled = true;
        }
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
