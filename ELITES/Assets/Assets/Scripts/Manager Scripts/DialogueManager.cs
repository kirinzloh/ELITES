using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance { get; set; }

    public Text nameText;
    public Text dialogueText;
    public float text_delay;
    public Animator animator;

    private Queue<string> sentences;
    private Queue<string> names;
    private bool displayingSentence = false;
    private string name;
    private string sentence;

    public List<Cutscene> cutscenesList;
    public bool inDialogue = false;
    
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
            sentences = new Queue<string>();
            names = new Queue<string>();
        }
    }

    public void StartCutscene(int index)
    {
        Cutscene cutscene = cutscenesList[index];
        StartDialogue(cutscene.dialogue);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        QuestManager.instance.dialogueEnded = false;
        inDialogue = true;
        animator.SetBool("IsOpen", true);
    
        sentences.Clear();
        names.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        foreach (string name in dialogue.names)
        {
            names.Enqueue(name);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (displayingSentence)
        {
            StopAllCoroutines();
            dialogueText.text = sentence;
            displayingSentence = false;
        }
        else
        {
            if (sentences.Count == 0)
            {
                EndDialogue();
                return;
            }

            name = names.Dequeue();
            nameText.text = name;

            sentence = sentences.Dequeue();
            dialogueText.text = sentence;
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
        }
    }

    IEnumerator TypeSentence (string sentence)
    {
        displayingSentence = true;
        dialogueText.text = "";
        foreach (char letter in sentence)
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(text_delay);
        }
        displayingSentence = false;
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        inDialogue = false;
        QuestManager.instance.dialogueEnded = true;
     }

}
