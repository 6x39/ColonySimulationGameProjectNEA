using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonToggles : MonoBehaviour
{
    public bool digToggle = false;
    public bool buildToggle = false; // all of the following below will be tied to buildToggle in one way or another. These are the different tiles.
    public bool permitTiles = false;
    public bool basicToggle = false;
    public bool redToggle = false;
    public bool blueToggle = false;
    public bool greenToggle = false;
    public bool sandstoneToggle = false;

    public Button digButton;
    public Button buildButton; // same as above, all of the following will be tied to buildButton in one way or another. These are the buttons for each tile.
    public Button basicButton;
    public Button redButton;
    public Button blueButton;
    public Button greenButton;
    public Button sandstoneButton;
    
    public TMP_Text digButtonText;
    public TMP_Text buildButtonText; // yet again, same as above. 
    public TMP_Text basicButtonText;
    public TMP_Text redButtonText;
    public TMP_Text blueButtonText;
    public TMP_Text greenButtonText;
    public TMP_Text sandstoneButtonText;

    void Start()
    {
        basicButton.onClick.AddListener(() => individualTileActivation(basicButton, basicButtonText, ref basicToggle));
        redButton.onClick.AddListener(() => individualTileActivation(redButton, redButtonText, ref redToggle));
        blueButton.onClick.AddListener(() => individualTileActivation(blueButton, blueButtonText, ref blueToggle));
        greenButton.onClick.AddListener(() => individualTileActivation(greenButton, greenButtonText, ref greenToggle));
        sandstoneButton.onClick.AddListener(() => individualTileActivation(sandstoneButton, sandstoneButtonText, ref sandstoneToggle));

        basicButton.gameObject.SetActive(false);
        redButton.gameObject.SetActive(false);
        blueButton.gameObject.SetActive(false);
        greenButton.gameObject.SetActive(false);
        sandstoneButton.gameObject.SetActive(false);

        Debug.Log($"basicButton: {basicButton}");
        Debug.Log($"basicButtonText: {basicButtonText}");
        Debug.Log($"basicToggle: {basicToggle}");
    }

    public void DigButtonToggle()
    {
        if (buildToggle) buildToggle = !buildToggle; buildButtonText.color = Color.black;
        digToggle = !digToggle;
        if (digToggle) {digButtonText.color = Color.blue; buildButtonText.color = Color.black;} else digButtonText.color = Color.black;
    }

    public void BuildButtonToggle()
    {
        if (digToggle) digToggle = !digToggle; digButtonText.color = Color.black;
        buildToggle = !buildToggle;
        if (buildToggle) {buildButtonText.color = Color.blue; digButtonText.color = Color.black;} else buildButtonText.color = Color.black;
        tilePermittance();
    }

    public void tilePermittance()
    {
        if (buildToggle)
        {
            permitTiles = true;
        }
        else if (!buildToggle)
        {
            permitTiles = false;
        }
        // changing the state of activity for the buttons depending on if buildToggle has been pressed or not.
        // basically makes them visible or hides them.
        basicButton.gameObject.SetActive(permitTiles);
        redButton.gameObject.SetActive(permitTiles);
        blueButton.gameObject.SetActive(permitTiles);
        greenButton.gameObject.SetActive(permitTiles);
        sandstoneButton.gameObject.SetActive(permitTiles);
    }

    public void individualTileActivation(Button myButton, TMP_Text myText, ref bool myBool) 
    {
        myBool = !myBool;
        // this is the most elegant solution i could do without making array objects each time this is run, and then using 10 references to somehow change the reference of a reference of a reference
        // of a value in an array to change it in the entire program. This is a lot easier but looks a lot less elegant. I will change it in the future if I really want to make it look pretty.
        if (basicButton != myButton && basicToggle != false) basicToggle = false; basicButtonText.color = Color.black; redButtonText.color = Color.black; blueButtonText.color = Color.black; greenButtonText.color = Color.black; sandstoneButtonText.color = Color.black;
        if (redButton != myButton && redToggle != false) redToggle = false; basicButtonText.color = Color.black; redButtonText.color = Color.black; blueButtonText.color = Color.black; greenButtonText.color = Color.black; sandstoneButtonText.color = Color.black;
        if (blueButton != myButton && blueToggle != false) blueToggle = false; basicButtonText.color = Color.black; redButtonText.color = Color.black; blueButtonText.color = Color.black; greenButtonText.color = Color.black; sandstoneButtonText.color = Color.black;
        if (greenButton != myButton && greenToggle != false) greenToggle = false; basicButtonText.color = Color.black; redButtonText.color = Color.black; blueButtonText.color = Color.black; greenButtonText.color = Color.black; sandstoneButtonText.color = Color.black;
        if (sandstoneButton != myButton && sandstoneToggle != false) sandstoneToggle = false; basicButtonText.color = Color.black; redButtonText.color = Color.black; blueButtonText.color = Color.black; greenButtonText.color = Color.black; sandstoneButtonText.color = Color.black;

        if (myBool) myText.color = Color.blue; else myText.color = Color.black;
    }
}   
