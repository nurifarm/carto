using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

// GWS 통신을 위한 클래스
public class GWSClient : UniSingleton<GWSClient>
{
    static string URL = "http://183.91.201.152:8088/app/1.0/service/ajax";
    
    public IEnumerator Request(Dictionary<string, string> parameters)
    {

        // List<IMultipartFormSection> formData = new List<IMultipartFormSection>();

        // foreach(KeyValuePair<string, string> param in parameters)
        // {
        //     formData.Add(new MultipartFormDataSection(param.Key, param.Value));
        //     Debug.Log(param.Key);
        //     Debug.Log(param.Value);

        // }
        // Debug.Log(URL);

        //var json = JsonConvert.SerializeObject(parameters);
        

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
