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

    void RequestCompleted(ClientOutput clientOutput)
    {
        // TODO
        if (clientOutput.message != null) {
			var message = clientOutput.message;
			
			if (message == "OK")
            {
				Debug.Log("Success");
			} else
			{
				Debug.Log(message);
			}
		}
    }

    void ClickCard()
    {
        Dictionary<string, string> parameters = new Dictionary<string, string>()
        {
            {"serviceId", "gws.auth"},
            {"commandId", "doLogin"},
            {"userId", "admin"},
            {"password", "1234"}
        };

        Dictionary<string, string> parameters2 = new Dictionary<string, string>()
        {
            {"serviceId", "battle.stage"},
            {"commandId", "retrieveDetailList"},
            {"stageId", "0001"}
        };

        GWSClient.Instance.Request(parameters, RequestCompleted);
        GWSClient.Instance.Request(parameters2, RequestCompleted);

    }
    
}
