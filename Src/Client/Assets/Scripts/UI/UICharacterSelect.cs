using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Models;
using Services;
using SkillBridge.Message;
public class UICharacterSelect : MonoBehaviour {

    public GameObject panelCreate;
    public GameObject panelSelect;

    public Button returnBtn;
    public Button createButton;
    public Text title;
    public Text descs;


    public UICharacterView characterView;
    CharacterClass charClass;

    void Start () {

    }

    public void InitCharacterSelect()
    {
        panelCreate.SetActive(false);
        panelSelect.SetActive(true);

    }
        void Update () {
		
	}

    public void InitCharacterCreate()
    {
        panelSelect.SetActive(false);
        panelCreate.SetActive(true);

    }

    public void OnSelectClass(int charClass)
    {
        this.charClass = (CharacterClass)charClass;
        characterView.CurrentCharacter = charClass - 1;
        title.text= DataManager.Instance.Characters[charClass].Name;
        descs.text= DataManager.Instance.Characters[charClass].Description;
    }

    public void ReturnBtn()
    {
        SceneManager.Instance.LoadScene("Loading");
    }
}
