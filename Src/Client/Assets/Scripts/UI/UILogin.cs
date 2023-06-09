using Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SkillBridge.Message;

public class UILogin : MonoBehaviour {
    public InputField username;
    public InputField password;

    void Start()
    {
        UserService.Instance.OnLogin = OnLogin;
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void OnClickLogin()
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
        UserService.Instance.SendLogin(this.username.text, this.password.text);
    }

    void OnLogin(Result result, string message)
    {
        if (result == Result.Success)
        {
            SceneManager.Instance.LoadScene("CharSelect");
        }
        else
            MessageBox.Show(message, "错误", MessageBoxType.Error);
    }
}
