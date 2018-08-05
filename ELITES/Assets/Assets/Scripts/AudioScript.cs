using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioScript : MonoBehaviour {

    [SerializeField]
    private Image volumeBar;

    private AudioSource audioSrc;

    private float musicVolume = 1f;

    void Start()
    {
        audioSrc = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSource>();
    }

    void Update()
    {
        audioSrc.volume = musicVolume;
    }


    public void VolumeChange(float newVolume)
    {
        volumeBar.fillAmount = 1-newVolume;
        musicVolume = volumeBar.fillAmount;
    }

}
