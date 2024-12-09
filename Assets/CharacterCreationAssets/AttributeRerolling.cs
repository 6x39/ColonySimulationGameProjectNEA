using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

public class AttributeRerolling : MonoBehaviour
{
    string[] attributes = {"Strength", "Tidying", "Construction", "Speed", "Dexterity", "Stamina", "Intelligence"};
    private System.Random value = new System.Random();
    public void ButtonClickReroll(GameObject character)
    {
        Initialisation getChar = character.GetComponent<Initialisation>();
        while (!(getChar.attribute1 != getChar.attribute2 && getChar.attribute2 != getChar.attribute3))
        {
            getChar.attribute1 = attributes[value.Next(0, attributes.Length)];
            getChar.attribute2 = attributes[value.Next(0, attributes.Length)];
            getChar.attribute3 = attributes[value.Next(0, attributes.Length)];
            getChar.attribute1Ability = value.Next(0, 10);
            getChar.attribute2Ability = value.Next(0, 10);
            getChar.attribute3Ability = value.Next(0, 10);
            Debug.Log("yes yes things are actually going on in here");
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
