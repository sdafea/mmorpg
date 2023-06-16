using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Services;
using SkillBridge.Message;

public class UIRegister : MonoBehaviour {

    public InputField username;
    public InputField password;
    public InputField passwordConfirm;
    public Button buttonRegister;

    public GameObject uiLogin;

    void Start () {
        UserService.Instance.OnRegister = this.OnRegister;
	}
    
	
	void Update () {
		
	}

    public void OnClickRegister()
    {
        if (string.IsNullOrEmpty(this.username.text))
        {
            MessageBox.Show("请输入用户名");
            return;
        }
        if (string.IsNullOrEmpty(this.password.text))
        {
            MessageBox.Show("请输入密码");
            return;
        }
        if (string.IsNullOrEmpty(this.passwordConfirm.text))
        {
            MessageBox.Show("请输入确认密码");
            return;
        }
        if (this.password.text != this.passwordConfirm.text)
        {
            MessageBox.Show("两次输入的密码不一致");
            return;
        }
        UserService.Instance.SendRegister(this.username.text, this.password.text);
    }

    void OnRegister(Result result, string message)
    {
        if (result == Result.Success)
        {
            //登录成功，进入角色选择
            MessageBox.Show("注册成功,请登录", "提示", MessageBoxType.Information).OnYes = this.CloseRegister;
        }
        else
            MessageBox.Show(message, "错误", MessageBoxType.Error);
    }
    
    public void CloseRegister()
    {
        this.gameObject.SetActive(false);
        uiLogin.SetActive(true);
    }

}
