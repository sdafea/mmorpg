using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICharacterSelect : MonoBehaviour {

    public GameObject PanelCreate;
    public GameObject PanelSelect;

    public Button CreateButton;
    public Button SelectBtn1;
    public Button SelectBtn2;
    public Button SelectBtn3;

    public GameObject Chacter1;
    public GameObject Chacter2;
    public GameObject Chacter3;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Select1()
    {
        Chacter1.SetActive(true);
        Chacter2.SetActive(false);
        Chacter3.SetActive(false);
    }
}
