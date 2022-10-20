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
        ClientOutput clientOutput = await LoginManager.Instance.Login(userId.text, password.text);
        
        if (clientOutput.message == "OK")
        {
            //await GameDataManager.Instance.LoadUserData(clientOutput);
            await CSceneManager.Instance.Change("MainScene");
        }
        else 
        {
            // TODO : 실패 팝업
            Debug.LogError("error: " + clientOutput.message);
        }
    }

}
