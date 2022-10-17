using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class LoginScene : SceneBase
{
    public TMP_InputField userId;
    public TMP_InputField password;
    public Button btn;


    void Awake()
    {
        btn.onClick.AddListener(BtnClickHandler);
    }

    void BtnClickHandler()
    {
        LoginManager.Instance.Login(userId.text, password.text, OnCompleteLogin);
    }

	void OnCompleteLogin(bool success)
	{
		if(success) {
			CSceneManager.Instance.LoadScene("MainScene");
 		} else {
			// fail popup
		}

	}
}
