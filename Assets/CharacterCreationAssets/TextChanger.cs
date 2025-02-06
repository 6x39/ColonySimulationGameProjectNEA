using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TextChanger : MonoBehaviour
{
    public TMP_Text tmptext;
    public Initialisation character;

    void Update()
    {
        if (character.attribute1 != String.Empty && character.attribute2 != String.Empty && character.attribute3 != String.Empty)
        {
            tmptext.text = $"{character.attribute1}: {character.attribute1Ability} \n{character.attribute2}: {character.attribute2Ability} \n{character.attribute3}: {character.attribute3Ability}";
        }
    }
}
