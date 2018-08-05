using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgression : MonoBehaviour {

    public int quest = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void QuestCompleted()
    {
        quest += 1;
    }

    public int getQuestLevel()
    {
        return quest;
    }
}
