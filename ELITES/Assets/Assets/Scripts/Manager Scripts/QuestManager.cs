using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour {

    public static QuestManager instance { get; set; }

    public Text questTitle;
    public Text questDescription;
    public GameObject PlayerFainted;
    public GameObject QuestBox;

    public List<Quest> quests;
    public Quest currentQuest;
    private int questLevel;
    private Cutscene cutscene;
    private int index;
    public bool inCutscene = false;
    public bool triggeredCutscene = false;
    public bool dialogueEnded = false;

    // Scenes    
    public GameObject scene1;
    public GameObject scene2;
    public GameObject scene3;
    public GameObject scene4;
    public GameObject scene5;


    // Use this for initialization
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

    // Update is called once per frame
    void Update () {
        questLevel = PlayerManager.instance.getQuestLevel();
        Debug.Log("Quest Level: " + questLevel);
        switch (questLevel)
        {
            case 0:
                scene1.SetActive(true);
                index = 0;
                currentQuest = quests[index];
                cutscene = DialogueManager.instance.cutscenesList[index];
                if (cutscene.isCompleted)
                {
                    PlayerFainted.SetActive(false);
                    PlayerManager.instance.questLevel += 1;
                }
                else
                {
                    if (inCutscene == false)
                    {
                        PlayerFainted.SetActive(true);
                        inCutscene = true;
                        DialogueManager.instance.StartCutscene(index);
                    }
                    else
                    {
                        if (inCutscene && dialogueEnded)
                        {
                            cutscene.isCompleted = true;
                            inCutscene = false;
                            dialogueEnded = false;
                        }
                    }
                }
                break;
            case 1:
                index = 1;
                cutscene = DialogueManager.instance.cutscenesList[index];
                if (cutscene.isCompleted)
                {
                    questTitle.text = currentQuest.title;
                    questDescription.text = currentQuest.description;
                    QuestBox.SetActive(true);
                }
                else
                {
                    if (inCutscene == false)
                    {
                        inCutscene = true;
                        DialogueManager.instance.StartCutscene(index);
                    }
                    else
                    {
                        if (inCutscene && dialogueEnded)
                        {
                            cutscene.isCompleted = true;
                            inCutscene = false;
                            dialogueEnded = false;
                        }
                    }
                }
                if (currentQuest.isCompleted)
                {
                    currentQuest = quests[index];
                    questTitle.text = currentQuest.title;
                    questDescription.text = currentQuest.description;
                    scene2.SetActive(true);
                    PlayerManager.instance.QuestCompleted();
                }
                break;
            case 2:
                index = 2;
                cutscene = DialogueManager.instance.cutscenesList[index];
                if (cutscene.isCompleted)
                {
                    scene1.SetActive(false);
                    currentQuest.isCompleted = true;
                }
                else
                {
                    if (inCutscene == false && triggeredCutscene)
                    {
                        inCutscene = true;
                        triggeredCutscene = false;
                        DialogueManager.instance.StartCutscene(index);
                    }
                    else
                    {
                        if (inCutscene && dialogueEnded)
                        {
                            cutscene.isCompleted = true;
                            inCutscene = false;
                            dialogueEnded = false;
                        }
                    }
                }
                if (currentQuest.isCompleted)
                {
                    currentQuest = quests[index];
                    questTitle.text = currentQuest.title;
                    questDescription.text = currentQuest.description;
                    PlayerManager.instance.QuestCompleted();
                }
                break;
            case 3:
                index = 3;
                cutscene = DialogueManager.instance.cutscenesList[index];
                if (cutscene.isCompleted)
                {
                    currentQuest = quests[index];
                    questTitle.text = currentQuest.title;
                    questDescription.text = currentQuest.description;
                    PlayerManager.instance.questLevel += 1;
                }
                else
                {
                    if (inCutscene == false && triggeredCutscene)
                    {
                        inCutscene = true;
                        triggeredCutscene = false;
                        DialogueManager.instance.StartCutscene(index);
                    }
                    else
                    {
                        if (inCutscene && dialogueEnded)
                        {
                            cutscene.isCompleted = true;
                            inCutscene = false;
                            dialogueEnded = false;
                        }
                    }
                }
                break;
            case 4:
                index = 4;
                if (currentQuest.isCompleted)
                {
                    PlayerManager.instance.QuestCompleted();
                }
                break;
            case 5:
                index = 5;
                scene3.SetActive(true);
                scene2.SetActive(false);
                cutscene = DialogueManager.instance.cutscenesList[index];
                if (cutscene.isCompleted)
                {
                    currentQuest = quests[index];
                    questTitle.text = currentQuest.title;
                    questDescription.text = currentQuest.description;
                    currentQuest.isCompleted = true;
                }
                else
                {
                    if (inCutscene == false && triggeredCutscene)
                    {
                        inCutscene = true;
                        triggeredCutscene = false;
                        DialogueManager.instance.StartCutscene(index);
                    }
                    else
                    {
                        if (inCutscene && dialogueEnded)
                        {
                            cutscene.isCompleted = true;
                            inCutscene = false;
                            dialogueEnded = false;
                        }
                    }
                }
                if (currentQuest.isCompleted)
                {
                    PlayerManager.instance.QuestCompleted();
                }
                break;
            case 6:
                index = 6;
                currentQuest = quests[index];
                questTitle.text = currentQuest.title;
                questDescription.text = currentQuest.description;
                cutscene = DialogueManager.instance.cutscenesList[index];
                if (cutscene.isCompleted)
                {
                    currentQuest.isCompleted = true;
                }
                else
                {
                    if (inCutscene == false && triggeredCutscene)
                    {
                        inCutscene = true;
                        triggeredCutscene = false;
                        DialogueManager.instance.StartCutscene(index);
                    }
                    else
                    {
                        if (inCutscene && dialogueEnded)
                        {
                            cutscene.isCompleted = true;
                            inCutscene = false;
                            dialogueEnded = false;
                        }
                    }
                }
                if (currentQuest.isCompleted)
                {
                    PlayerManager.instance.QuestCompleted();
                }
                break;
            case 7:
                index = 7;
                currentQuest = quests[index];
                questTitle.text = currentQuest.title;
                questDescription.text = currentQuest.description;
                cutscene = DialogueManager.instance.cutscenesList[index];
                if (cutscene.isCompleted)
                {
                    currentQuest.isCompleted = true;
                }
                else
                {
                    if (inCutscene == false && triggeredCutscene)
                    {
                        inCutscene = true;
                        triggeredCutscene = false;
                        DialogueManager.instance.StartCutscene(index);
                    }
                    else
                    {
                        if (inCutscene && dialogueEnded)
                        {
                            cutscene.isCompleted = true;
                            inCutscene = false;
                            dialogueEnded = false;
                        }
                    }
                }
                if (currentQuest.isCompleted)
                {
                    PlayerManager.instance.QuestCompleted();
                }
                break;
            case 8:
                index = 8;
                cutscene = DialogueManager.instance.cutscenesList[index];
                if (cutscene.isCompleted)
                {
                    PlayerManager.instance.questLevel += 1;
                }
                else
                {
                    if (inCutscene == false && triggeredCutscene)
                    {
                        inCutscene = true;
                        triggeredCutscene = false;
                        DialogueManager.instance.StartCutscene(index);
                    }
                    else
                    {
                        if (inCutscene && dialogueEnded)
                        {
                            cutscene.isCompleted = true;
                            inCutscene = false;
                            dialogueEnded = false;
                        }
                    }
                }
                break;
            case 9:
                index = 9;
                scene4.SetActive(true);
                currentQuest = quests[index];
                questTitle.text = currentQuest.title;
                questDescription.text = currentQuest.description;
                cutscene = DialogueManager.instance.cutscenesList[index];
                if (cutscene.isCompleted)
                {
                    currentQuest.isCompleted = true;
                }
                else
                {
                    if (inCutscene == false && triggeredCutscene)
                    {
                        inCutscene = true;
                        triggeredCutscene = false;
                        DialogueManager.instance.StartCutscene(index);
                    }
                    else
                    {
                        if (inCutscene && dialogueEnded)
                        {
                            cutscene.isCompleted = true;
                            inCutscene = false;
                            dialogueEnded = false;
                        }
                    }
                }
                if (currentQuest.isCompleted)
                {
                    PlayerManager.instance.QuestCompleted();
                }
                break;
            case 10:
                index = 10;
                QuestBox.SetActive(false);
                scene3.SetActive(false);
                PlayerFainted.SetActive(true);
                cutscene = DialogueManager.instance.cutscenesList[index];
                if (cutscene.isCompleted)
                {
                    PlayerFainted.SetActive(false);
                    PlayerManager.instance.questLevel += 1;
                }
                else
                {
                    if (inCutscene == false && triggeredCutscene)
                    {
                        inCutscene = true;
                        triggeredCutscene = false;
                        DialogueManager.instance.StartCutscene(index);
                    }
                    else
                    {
                        if (inCutscene && dialogueEnded)
                        {
                            cutscene.isCompleted = true;
                            inCutscene = false;
                            dialogueEnded = false;
                        }
                    }
                }
                break;
            case 11:
                index = 11;
                cutscene = DialogueManager.instance.cutscenesList[index];
                if (cutscene.isCompleted)
                {
                    PlayerFainted.SetActive(true);
                    PlayerManager.instance.questLevel += 1;
                }
                else
                {
                    if (inCutscene == false && triggeredCutscene)
                    {
                        inCutscene = true;
                        triggeredCutscene = false;
                        DialogueManager.instance.StartCutscene(index);
                    }
                    else
                    {
                        if (inCutscene && dialogueEnded)
                        {
                            cutscene.isCompleted = true;
                            inCutscene = false;
                            dialogueEnded = false;
                        }
                    }
                }
                break;
            case 12:
                index = 12;
                scene5.SetActive(true);
                scene4.SetActive(false);
                cutscene = DialogueManager.instance.cutscenesList[index];
                if (cutscene.isCompleted)
                {
                    PlayerFainted.SetActive(false);
                    PlayerManager.instance.questLevel += 1;
                }
                else
                {
                    if (inCutscene == false && triggeredCutscene)
                    {
                        inCutscene = true;
                        triggeredCutscene = false;
                        DialogueManager.instance.StartCutscene(index);
                    }
                    else
                    {
                        if (inCutscene && dialogueEnded)
                        {
                            cutscene.isCompleted = true;
                            inCutscene = false;
                            dialogueEnded = false;
                        }
                    }
                }
                break;
            default:
                Debug.Log("No active quests");
                break;
        }
	}
}
