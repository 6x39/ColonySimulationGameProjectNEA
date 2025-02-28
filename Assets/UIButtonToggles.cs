using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonToggles : MonoBehaviour
{
    [SerializeField] bool digToggle = false;
    public Button digButton;
    public TMP_Text digButtonText;

    public void DigButtonToggle()
    {
        digToggle = !digToggle;
        if (digToggle) digButtonText.color = Color.blue; else digButtonText.color = Color.black;
    }
}
