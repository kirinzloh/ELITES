using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    public GameObject GameOverUI;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerHealth>().isDead)
        {
            GameOverUI.SetActive(true);
            Time.timeScale = 0f;
        }
        
    }

}
