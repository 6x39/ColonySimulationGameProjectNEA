using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

public class AttributeRerolling : MonoBehaviour
{
    // creating an attribute array so we can assign random attributes to each character.
    string[] attributes = {"Strength", "Tidying", "Construction", "Speed", "Dexterity", "Stamina", "Intelligence"};
    // making an object of the Random class so we can randomize which attribute a character will be assigned.
    private System.Random value = new System.Random();
    public void ButtonClickReroll(GameObject character)
    {
        // this bit is just for readability.
        Initialisation getChar = character.GetComponent<Initialisation>();
        do 
        {
            // this goes to the Initialisation class and grabs the variables "attribute1/2/3" so we can assign the variables values from a different script. the same thing is done for the "level" of the attributes.
            getChar.attribute1 = attributes[value.Next(0, attributes.Length)];
            getChar.attribute2 = attributes[value.Next(0, attributes.Length)];
            getChar.attribute3 = attributes[value.Next(0, attributes.Length)];
            getChar.attribute1Ability = value.Next(0, 10);
            getChar.attribute2Ability = value.Next(0, 10);
            getChar.attribute3Ability = value.Next(0, 10);
        }   while (!(getChar.attribute1 != getChar.attribute2 && getChar.attribute2 != getChar.attribute3));
        // a do while is used instead of a while loop so whenever the button clicks it always performs at least one iteration, otherwise it wouldn't work if you wanted to reroll multiple times.
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
