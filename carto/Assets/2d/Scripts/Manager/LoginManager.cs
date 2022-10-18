using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LoginManager : UniSingleton<LoginManager>
{
	private bool isBusy = false;
	private System.Action<bool> loginCallback;

    public void Login(string userId, string password, System.Action<bool> callback = null)
    {
		// ------------------------------------------------------------
		// check for already processing
		// ------------------------------------------------------------
		if (!isBusy)
		{
			// ------------------------------------------------------------
			// check for required parameters
			// ------------------------------------------------------------
			if (userId != null && password != null)
			{
				isBusy = true;
				loginCallback = callback;

				// ------------------------------------------------------------
				// make parameters
				// ------------------------------------------------------------
				Dictionary<string, string> parameters = new Dictionary<string, string>()
				{
					{"serviceId", "gws.auth"},
					{"commandId", "doLogin"},
					{"userId", userId},
					{"password", password}
				};

				// ------------------------------------------------------------
				// excute request
				// ------------------------------------------------------------
				GWSClient.Instance.Request(parameters, RequestCompleted);	
			}
			else
			{
				callback?.Invoke(false);
				Debug.Log("필수 파라미터 항목이 누락되었습니다.");
				return;
			}
		}
		else
		{
			callback?.Invoke(false);
			Debug.Log("이미 처리 중 입니다.");
			return;
		}
    }

    public void RequestCompleted(ClientOutput clientOutput)
    {
        if (clientOutput != null) {
			var message = clientOutput.message;

			if (message == "OK")
            {
				loginCallback?.Invoke(true);
			} 
			else
			{
				Debug.Log("로그인에 실패하였습니다.: " + message);
			}
		} 
		else 
		{
			loginCallback?.Invoke(false);
			Debug.Log("로그인에 실패하였습니다.: clientOutput is null");
		}

		loginCallback = null;
		isBusy = false;

	}


}
