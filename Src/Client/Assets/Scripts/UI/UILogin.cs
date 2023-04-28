using Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILogin : MonoBehaviour {
    public InputField username;
    public InputField password;

    void Start()
    {
        UserService.Instance.OnLogin = this.OnLogin;
    }

    void OnLogin(SkillBridge.Message.Result result, string msg)
    {
        MessageBox.Show(string.Format("结果：{0} msg:{1}", result, msg));
    }

    // Update is called once per frame
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
        UserService.Instance.SendLogin(this.username.text, this.password.text);
    }
}
