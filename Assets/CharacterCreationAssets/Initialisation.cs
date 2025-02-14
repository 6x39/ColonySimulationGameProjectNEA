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

    void Start()
    {
        character.AddComponent(typeof(BoxCollider2D));
    }

    void Awake()
    {
        // this is so the object (character) will not be destroyed upon creation when we move them between scenes (like playing the game). 
        Object.DontDestroyOnLoad(character);
    }

    // Update is called once per frame
    void Update()
    {
        if (character.transform.localScale.x != 1 && character.transform.localScale.y != 1 && character.transform.localScale.z != 1 && SceneManager.GetActiveScene().name == "MainGameScene")
        {
            character.transform.localScale = new Vector3(1, 1.8f, 1); // this is just to change the scaling of the people so they look more like people... 
        }
    }

    void DestroyCharacter()
    {
        Destroy(character); // this is just for killing the user later on and stuff. also so i can destroy them whenever I want.
    }
}
