using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using Cysharp.Threading.Tasks;


public class LoginScene : SceneBase
{
    public TMP_InputField userId;
    public TMP_InputField password;
    public Button btn;

    void Awake()
    {
        btn.onClick.AddListener(BtnClickHandler);
    }

    async void BtnClickHandler()
    {
        btn.interactable = false;
        await LoginManager.Instance.Login(userId.text, password.text);
        btn.interactable = true;
    }

}
