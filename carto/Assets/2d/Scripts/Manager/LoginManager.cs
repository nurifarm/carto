using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginManager : UniSingleton<LoginManager>
{
    public void Login(string userId, string password)
    {
        Dictionary<string, string> parameters = new Dictionary<string, string>()
        {
            {"serviceId", "gws.auth"},
            {"commandId", "doLogin"},
            {"userId", userId},
            {"password", password}
        };

        GWSClient.Instance.Request(parameters, RequestCompleted);
    }

    public void RequestCompleted(ClientOutput clientOutput)
    {
        if (clientOutput.message != null) {
			var message = clientOutput.message;
			
			if (message == "OK")
            {
				Debug.Log("Login Success");
                CSceneManager.Instance.LoadScene("MainScene");
			} else
			{
				Debug.Log(message);
			}
		}
    }


}
