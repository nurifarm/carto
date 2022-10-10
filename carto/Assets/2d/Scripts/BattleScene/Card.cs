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

        void ajaxCompleted()
        {
            Debug.Log("ajaxcompleted");
        }

        GWSManager.parameter(parameters).done(ajaxCompleted).excute();
        Debug.Log("click");
    }
    
}
