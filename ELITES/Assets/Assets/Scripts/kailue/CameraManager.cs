using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    public Camera[] cameraArray;
    public GameObject[] players;
    public Transform[] playerSpawnPoints; 

	// Use this for initialization
	void Start () {
        Debug.Log("Camera Manager started");
        cameraArray[0].enabled = true;
        cameraArray[1].enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.C))
        {
            SwitchCamera();
        }
    }

    public void SwitchCamera()
    {
        Debug.Log("Camera changed");
        cameraArray[0].enabled = !cameraArray[0].enabled;
        cameraArray[1].enabled = !cameraArray[1].enabled;
    }

    public void SetCamera(int world, int map)
    {
        cameraArray[0].enabled = false;
        cameraArray[1].enabled = false;

        cameraArray[world].transform.Translate(playerSpawnPoints[map].position);
    }

    public void SetPlayerPosition(int world, int map)
    {
        players[world].transform.Translate(playerSpawnPoints[map].position);
    }
}
