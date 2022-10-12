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

    public IEnumerator Request(Dictionary<string, string> parameters)
    {
        using (UnityWebRequest www = UnityWebRequest.Post(URL, parameters))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("error");
                Debug.Log(www.error);
            }
            else
            {

                Debug.Log("success");
                Debug.Log(www.downloadHandler.text);
            }
        }
        
    }
}
