using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;

class CSceneManager : UniSingleton<CSceneManager>
{
	static string toSceneName = "LoginScene";
	public void LoadScene(string sceneName)
	{
		toSceneName = sceneName;
		SceneManager.LoadScene("LoadingScene");
	}

	public async UniTask Change()
	{
		await SceneManager.LoadSceneAsync(toSceneName);
	}

}
