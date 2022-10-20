using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using Cysharp.Threading.Tasks;

/// <summary>
/// GameWebServer 통신 클래스
/// </summary>
public class GWSClient
{
    // 개발 서버
    static string URL = "http://183.91.201.152:8088/app/1.0/service/ajax";


    /// <summary>
    /// <param name="parameters">호출 서비스 및 넘겨줄 파라미터</param>
    /// GWSClient.Instance.Request(parameters);
    /// </summary>
	public static async UniTask<T> Request<T>(Dictionary<string, string> parameters)
	{
        using (UnityWebRequest request = UnityWebRequest.Post(URL, parameters))
        {
            try 
            {
                var res = await request.SendWebRequest();
                T result = JsonConvert.DeserializeObject<T>(res.downloadHandler.text);

                return result;
            }
            catch(Exception e)
            {
                // TODO : 실패 팝업
                Debug.LogError("error: " + e.Message);
                return default;
            }
        }
	}
}
