using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class GWSManager : Singleton<GWSManager>
{
    public Dictionary<string, string> _params = null;
    public delegate void Callback();
    public Callback _ajaxCompleted = null;

    public GWSManager parameter(Dictionary<string, string> p)
    {
        _params = p;
        return this;
    }

    public GWSManager done(Callback ajaxCompleted)
    {
        _ajaxCompleted = ajaxCompleted;
        return this;
    }

    public void excute()
    {
        string serviceId = "battle.stage";
        string commandId = "retrieveDetailList";

        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        formData.Add(new MultipartFormDataSection("serviceId", serviceId));
        formData.Add(new MultipartFormDataSection("commandId", commandId));

        UnityWebRequest www = UnityWebRequest.Post("http://183.91.201.152:8088/app/1.0/service/ajax", formData);

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            //_ajaxCompleted(www.result);
            Debug.Log(www.result);
        }
    }
}
