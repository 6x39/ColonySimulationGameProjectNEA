using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonToggles : MonoBehaviour
{
    public bool digToggle = false;
    public bool buildToggle = false;

    public Button digButton;
    public Button buildButton;

    public TMP_Text digButtonText;
    public TMP_Text buildButtonText;

    public void DigButtonToggle()
    {
        if (buildToggle) buildToggle = !buildToggle; buildButtonText.color = Color.black;
        digToggle = !digToggle;
        if (digToggle) digButtonText.color = Color.blue; else digButtonText.color = Color.black;
    }

    public void BuildButtonToggle()
    {
        if (digToggle) digToggle = !digToggle; digButtonText.color = Color.black;
        buildToggle = !buildToggle;
        if (buildToggle) buildButtonText.color = Color.blue; else buildButtonText.color = Color.black;
    }
}   
