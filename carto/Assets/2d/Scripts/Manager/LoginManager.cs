using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginManager : UniSingleton<LoginManager>
{
	private bool isBusy = false;
	private System.Action<bool> loginCallback;

    public void Login(string userId, string password, System.Action<bool> callback = null)
    {
		if (isBusy)
		{
			callback?.Invoke(false);
			return;
		}

		loginCallback = callback;


		Dictionary<string, string> parameters = new Dictionary<string, string>()
        {
            {"serviceId", "gws.auth"},
            {"commandId", "doLogin"},
            {"userId", userId},
            {"password", password}
        };
		isBusy = true;

        GWSClient.Instance.Request(parameters, RequestCompleted);
    }

    public void RequestCompleted(ClientOutput clientOutput)
    {
        if (clientOutput.message != null) {
			var message = clientOutput.message;

			bool success = message == "OK";
			loginCallback?.Invoke(success);

			if (message == "OK")
            {
				Debug.Log("Login Success");
			} else
			{
				Debug.Log(message);
			}
		} else {
			loginCallback?.Invoke(false);
		}

		loginCallback = null;
		isBusy = false;

	}


}
