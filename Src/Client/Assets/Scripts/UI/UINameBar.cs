using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entities;
using UnityEngine.UI;
using Models;

public class UINameBar : MonoBehaviour {

    public Text avaverName;
    public Character character;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.UpdateInfo();
        this.transform.forward = Camera.main.transform.forward;
	}

    void UpdateInfo()
    {
        if (character != null)
        {
            string name = character.Name + " Lv." + character.Info.Level;
            if(name != avaverName.text)
            {
                avaverName.text = name;
            }
        }
    }
}
