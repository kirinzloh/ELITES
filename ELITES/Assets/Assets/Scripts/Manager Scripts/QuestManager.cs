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
    public GameObject scene6;


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
            case 0: // Wake up in HQ
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
            case 1: // Speaks to Ad, receive first mission
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
            case 2: // spoke to Lionel, move to village
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
            case 3: // find monster lurking in village
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
            case 4: // kill monster then talk to commander
                index = 4;
                if (currentQuest.isCompleted)
                {
                    PlayerManager.instance.QuestCompleted();
                }
                break;
            case 5: // find hidden entrance in oddball's hideout
                index = 5;
                scene3.SetActive(true);
                currentQuest = quests[index];
                cutscene = DialogueManager.instance.cutscenesList[index];
                if (cutscene.isCompleted)
                {
                    scene2.SetActive(false);
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
            case 6: // Eliminate all the monsters
                index = 6;
                currentQuest = quests[index];
                cutscene = DialogueManager.instance.cutscenesList[index];
                if (cutscene.isCompleted)
                {
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
            case 7: // Kill Gigante (before entrance)
                index = 7;
                currentQuest = quests[index];
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
            case 8: // Enter room with Gigante, kill him.
                index = 8;
                cutscene = DialogueManager.instance.cutscenesList[index];
                if (cutscene.isCompleted)
                {
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
            case 9: // Interact with device and faints
                index = 9;
                scene4.SetActive(true);
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
            case 10:    // Fainted and back in HQ
                index = 10;
                QuestBox.SetActive(false);
                scene3.SetActive(false);
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
                        PlayerFainted.SetActive(true);
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
            case 11:    // Ongoing dialogue with psychiatrist and commander
                index = 11;
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
            case 12:    //  Before moving to final dungeon
                index = 12;
                scene5.SetActive(true);
                scene4.SetActive(false);
                cutscene = DialogueManager.instance.cutscenesList[index];
                if (cutscene.isCompleted)
                {
                    PlayerManager.instance.questLevel += 1;
                }
                else
                {
                    if (inCutscene == false && triggeredCutscene)
                    {
                        PlayerFainted.SetActive(true);
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
            case 13:    //  Final dungeon, sees lionel kill a human
                index = 13;
                PlayerFainted.SetActive(false);
                break;
            case 14:    //  Lionel runs away, start of chase
                index = 14;
                break;
            case 15:    //  Chase after Lionel
                index = 15;
                cutscene = DialogueManager.instance.cutscenesList[index];
                if (cutscene.isCompleted)
                {
                    currentQuest = quests[index];
                    questTitle.text = currentQuest.title;
                    questDescription.text = currentQuest.description;
                    QuestBox.SetActive(true);
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
            case 16:    // Stop Lionel from killing the woman
                index = 16;
                cutscene = DialogueManager.instance.cutscenesList[index];
                if (cutscene.isCompleted)
                {
                    scene5.SetActive(false);
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
            case 17:    // The Reveal
                index = 17;
                cutscene = DialogueManager.instance.cutscenesList[index];
                currentQuest = quests[index];
                questTitle.text = currentQuest.title;
                questDescription.text = currentQuest.description;
                if (cutscene.isCompleted)
                {
                    currentQuest.isCompleted = true;
                }
                else
                {
                    if (inCutscene == false && triggeredCutscene)
                    {
                        scene5.SetActive(true);
                        QuestBox.SetActive(false);
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
            case 18:    // Captured by lionel
                index = 18;
                scene6.SetActive(true);
                cutscene = DialogueManager.instance.cutscenesList[index];
                if (cutscene.isCompleted)
                {
                    PlayerManager.instance.questLevel += 1;
                    PlayerFainted.SetActive(true);
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
            case 19:    // Final confrontation with psychiatrist
                index = 19;
                cutscene = DialogueManager.instance.cutscenesList[index];
                PlayerFainted.SetActive(false);
                if (cutscene.isCompleted)
                {
                    Debug.Log("Game has ended");
                    gameObject.GetComponent<LoadSceneOnClick>().LoadByIndex(3);
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
