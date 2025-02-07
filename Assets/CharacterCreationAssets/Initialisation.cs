using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

public class Initialisation : MonoBehaviour
{
    // Creating all of the stuff that the character needs to have (its attributes)
    public GameObject character;
    public Rigidbody2D characterRigidBody;
    public int characterHealth = 100;
    public int characterFood = 4000;
    public int characterThirst = 10;
    public string attribute1;
    public string attribute2;
    public string attribute3;
    public int attribute1Ability;
    public int attribute2Ability;
    public int attribute3Ability;

    void Awake()
    {
        // this is so the object (character) will not be destroyed upon creation when we move them between scenes (like playing the game). 
        Object.DontDestroyOnLoad(character);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            characterRigidBody.velocity = Vector2.up * 5;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log($"attribute1 = {attribute1}, attribute2 = {attribute2}, attribute3 = {attribute3}. etc etc, if this works the other stuff does too.");

        }
        /* THIS WILL BE CHANGED AT A LATER DATE SO ANY ISSUES WITH WIDTH/HEIGHT OF THE PROGRAM IT WILL AUTOMATICALLY SCALE.
        if (SceneManager.GetActiveScene().name == "CharacterCreationScene")
        {

        }
        */
    }

    void DestroyCharacter()
    {
        Destroy(character); // this is just for killing the user later on and stuff. also so i can destroy them whenever I want.
    }
}
