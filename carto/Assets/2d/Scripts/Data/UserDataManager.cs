using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// User Data 관리 클래스
/// </summary>
public class UserDataManager : Singleton<UserDataManager>
{
    // User Data
    UserData userData;

    // Save
    public void Save()
    {

    }

    // Load
    public void Load() 
    {
        Dictionary<string, string> parameters = new Dictionary<string, string>();
        
        string serviceId = "battle.stage";
        string commandId = "retrieveDetailList";
        string stageNo = "1";

        parameters.Add("serviceId", serviceId);
        parameters.Add("commandId", commandId);
        parameters.Add("stageNo", stageNo);


        GWSClient.Instance.Request(parameters, RequestCompleted);
    }

    void RequestCompleted(ClientOutput clientOutput)
    {
        // TODO
    }
}
