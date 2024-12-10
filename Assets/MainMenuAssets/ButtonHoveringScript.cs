using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ButtonHoveringScript : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    public TextMeshProUGUI buttonText;
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("The cursor entered the selectable UI element.");
        buttonText.fontSize = Mathf.Lerp(64f, 70f, Time.deltaTime * 0.5f);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("The cursor exited the selectable UI element.");
        if (buttonText.fontSize > 64f) 
        {
            buttonText.fontSize = Mathf.Lerp(70f, 64f, Time.deltaTime * 0.5f);
        }
    }
}
// will come to this later, as I'm not sure why it's not working.
// The TextMeshProUGUI buttonText object isn't being classed as an object for some reason, so it's preventing my code from working properly.
// Additionally, whenever the pointer enters the button, nothing actually happens.
