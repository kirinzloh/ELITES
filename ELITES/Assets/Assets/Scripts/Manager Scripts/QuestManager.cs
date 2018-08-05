using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour {

    public static QuestManager Instance { get; set; }

    public Text questTitle;
    public Text questDescription;

    public List<Quest> quests;
    
    // Use this for initialization
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update () {
        questTitle.text = quests[0].title;
        questDescription.text = quests[0].description;
	}
}
