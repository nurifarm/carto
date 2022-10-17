using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;

public class LoadingScene : SceneBase
{
    void Start()
    {
        Load().Forget();
    }

    public async UniTaskVoid Load()
	{
        // dummy loading..
      //  await UniTask.Delay(4000);
        // Load Scene
      //  await CSceneManager.Instance.Change();
	}
}
