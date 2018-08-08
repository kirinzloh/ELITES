using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioScript : MonoBehaviour {

    [SerializeField]
    private Image volumeBar;

    public AudioMixer mixer;

    private float musicVolume;

    void Start()
    {
        
    }

    void Update()
    {
        mixer.SetFloat("musicVol", Mathf.Log(musicVolume) * 20);
    }

    public void VolumeChange(float newVolume)
    {
        volumeBar.fillAmount = 1-newVolume;
        musicVolume = volumeBar.fillAmount;
    }

}
