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


    }
    
}
