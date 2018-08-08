using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCutscene : MonoBehaviour {

    public int questLevel;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (PlayerManager.instance.getQuestLevel() >= questLevel && col.tag == "Player" && questLevel != 15)
        {
            Debug.Log("Triggered Cutscene");
            QuestManager.instance.triggeredCutscene = true;

            if (questLevel != 16){
                SpawnEnemy spawn = transform.GetComponent<SpawnEnemy>();
                if (spawn != null)
                {
                    spawn.enabled = true;
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (questLevel == 16)
        {
            SpawnEnemy spawn = transform.GetComponent<SpawnEnemy>();
            if (spawn != null)
            {
                spawn.enabled = true;
            }
        }
        if (questLevel == 15)
        {
            Debug.Log("Triggered Cutscene");
            QuestManager.instance.triggeredCutscene = true;
        }
        if (PlayerManager.instance.getQuestLevel() > questLevel)
        {
            Destroy(this);
        }
    }
}
