using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour {
    public AudioSource playerAtt;
    public AudioSource playerTrueStrike;
    public AudioSource playerCleave;
    public AudioSource playerStun;
    public AudioSource playerDamaged;
    public AudioSource skeletonAtt;
    public AudioSource skeletonDie;
    public AudioSource giganteFire;
    public AudioSource giganteDie;
    public AudioSource lionelAtt;
    public AudioSource lionelBomb;
    public AudioSource lionelClone;
    public AudioSource lionelDie;

    private static bool sfxmanExists;
    // Use this for initialization
    void Start () {
		if (!sfxmanExists)
        {
            sfxmanExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
	}
}
