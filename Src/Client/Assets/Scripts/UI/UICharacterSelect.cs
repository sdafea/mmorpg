using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Models;
using Services;
using SkillBridge.Message;
using System;

public class UICharacterSelect : MonoBehaviour {

    public GameObject panelCreate;
    public GameObject panelSelect;
    
    public Button createButton;
    public Text title;
    public Text descs;
    public InputField charName;
    public List<GameObject> uiChars = new List<GameObject>();

    public Transform uiCharList;
    public GameObject uiCharInfo;

    private int selectCharacterIdx = -1;

    public UICharacterView characterView;
    CharacterClass charClass;

    void Start () {
        InitCharacterSelect(true);
        UserService.Instance.OnCharacterCreate = OnCharacterCreate;
    }
    
    

    public void InitCharacterCreate()
    {
        panelCreate.SetActive(true);
        panelSelect.SetActive(false);
        OnSelectClass(1);
    }
    
    void Update () {
		
	}

    public void OnClickCreate()
    {
        if(string.IsNullOrEmpty(this.charName.text))
        {
            MessageBox.Show("请输入角色名称");
            return;
        }
        UserService.Instance.SendCharacterCreate(this.charName.text,this.charClass);
    }

    public void OnSelectClass(int charClass)
    {
        this.charClass = (CharacterClass)charClass;
        characterView.CurrentCharacter = charClass - 1;
        title.text = DataManager.Instance.Characters[charClass].Name;
        descs.text = DataManager.Instance.Characters[charClass].Description;
    }

    void OnCharacterCreate(Result result,string message)
    {
        if (result == Result.Success)
        {
            InitCharacterSelect(true);
        }
        else
            MessageBox.Show(message, "错误", MessageBoxType.Error);
    }

    public void InitCharacterSelect(bool init)
    {
        panelCreate.SetActive(false);
        panelSelect.SetActive(true);
        if (init)
        {
            foreach (var old in uiChars)
            {
                Destroy(old);
            }
            uiChars.Clear();
            for (int i = 0; i < User.Instance.Info.Player.Characters.Count; i++)
            {
                GameObject go = Instantiate(uiCharInfo, uiCharList);
                UICharInfo chrInfo = go.GetComponent<UICharInfo>();
                chrInfo.info = User.Instance.Info.Player.Characters[i];
                Button button = go.GetComponent<Button>();
                int idx = i;
                button.onClick.AddListener(() =>
                {
                    OnSelectCharacter(idx);
                });

                uiChars.Add(go);
                go.SetActive(true);
            }
            OnSelectCharacter(0);
        }
    }

    public void OnSelectCharacter(int idx)
    {
        selectCharacterIdx = idx;
        var cha = User.Instance.Info.Player.Characters[idx];
        Debug.LogFormat("Select Char:[{0}]{1}[{2}]", cha.Id, cha.Name, cha.Class);
        User.Instance.CurrentCharacter = cha;
        characterView.CurrentCharacter = ((int)cha.Class - 1);

        for(int i=0; i<User.Instance.Info.Player.Characters.Count;i++)
        {
            UICharInfo ci = this.uiChars[i].GetComponent<UICharInfo>();
            ci.Selected = idx == i;
        }
    }

    public void OnGameEnter(Result result, string message)
    {
        if (result == Result.Success)
        {
            SceneManager.Instance.LoadScene("MainCity");
        }
        else
            MessageBox.Show(message, "错误", MessageBoxType.Error);
    }

    public void OnClickPlay()
    {
        if (selectCharacterIdx >= 0)
        {
            UserService.Instance.SendGameEnter(selectCharacterIdx);
        }
    }

    public void SelectReturnBtn()
    {
        SceneManager.Instance.LoadScene("Loading");
    }

    public void CreatReturnBtn()
    {
        InitCharacterSelect(true);
    }
}
