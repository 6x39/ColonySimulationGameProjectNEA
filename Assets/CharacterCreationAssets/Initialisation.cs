using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
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
        // this is so the object (character) will not be destroyed upon creation. 
        Object.DontDestroyOnLoad(character);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            characterRigidBody.velocity = Vector2.up * 5;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log($"attribute1 = {attribute1}, attribute2 = {attribute2}, attribute3 = {attribute3}. etc etc, if this works the other stuff does too.");

        }
    }
}
