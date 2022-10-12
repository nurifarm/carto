using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerClickHandler
{
    private Image button;

    void Start() 
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ClickCard();
    }

    void ClickCard()
    {

        Dictionary<string, string> parameters = new Dictionary<string, string>();
        
        string serviceId = "battle.stage";
        string commandId = "retrieveDetailList";
        string stageNo = "1";

        parameters.Add("serviceId", serviceId);
        parameters.Add("commandId", commandId);
        parameters.Add("stageNo", stageNo);


        StartCoroutine(GWSClient.Instance.Request(parameters));
        Debug.Log("click");
    }
    
}
