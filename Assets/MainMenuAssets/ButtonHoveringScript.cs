using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ButtonHoveringScript : MonoBehaviour, IPointerExitHandler
{
    public TMP_Text buttonText;
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("The cursor entered the selectable UI element.");
        buttonText.fontSize += 10;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("The cursor exited the selectable UI element.");
        buttonText.fontSize -= 10;
    }
}
