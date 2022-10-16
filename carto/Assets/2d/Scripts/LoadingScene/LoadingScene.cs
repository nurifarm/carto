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

public class LoadingScene : SceneBase
{
    void Start()
    {
        Load().Forget();
    }

    public async UniTaskVoid Load()
	{
        await UniTask.Delay(10000);
        await CSceneManager.Instance.Change();
	}
}
