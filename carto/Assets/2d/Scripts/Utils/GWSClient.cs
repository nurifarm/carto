using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

/// <summary>
/// GameWebServer 통신 클래스
/// </summary>
public class GWSClient : UniSingleton<GWSClient>
{
    // 개발 서버
    static string URL = "http://183.91.201.152:8088/app/1.0/service/ajax";


    /// <summary>
    /// <param name="parameters">호출 서비스 및 넘겨줄 파라미터</param>
    /// <param name="callback">콜백 함수</param>
    /// GWSClient.Instance.Request(parameters, RequestCompleted);
    /// </summary>
	public void Request(Dictionary<string, string> parameters, Action<ClientOutput> callback)
	{
        StartCoroutine(DoRequest(parameters, callback));
	}

    public IEnumerator DoRequest(Dictionary<string, string> parameters, Action<ClientOutput> callback)
    {

        using (UnityWebRequest www = UnityWebRequest.Post(URL, parameters))
        {
            yield return www.SendWebRequest();
            
            ClientOutput clientOutput = new ClientOutput();

            if (www.result != UnityWebRequest.Result.Success)
            {
                clientOutput.message = www.error;
            }
            else
            {
                // Debug.Log(www.downloadHandler.text);
                clientOutput = JsonConvert.DeserializeObject<ClientOutput>(www.downloadHandler.text);
                
            }
            
            callback(clientOutput);
        }
        
    }
}
