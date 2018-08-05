using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BarScript : MonoBehaviour {

    [SerializeField]
    private float HP;
    [SerializeField]
    private float Energy;
    
    [SerializeField]
    private Image hpBar;
    [SerializeField]
    private Image energyBar;

    private float maxHP = 100;
    private float maxEnergy = 100;

    // Use this for initialization
	void Start ()
    {
		
	} 
	
	// Update is called once per frame
	void Update ()
    {
        HandleBar();
	}

    private void HandleBar()
    {
        hpBar.fillAmount = Map(HP, maxHP);
        energyBar.fillAmount = Map(Energy, maxEnergy);
    }

    private float Map(float current, float max)
    {
        return (current / max);
    }
}
