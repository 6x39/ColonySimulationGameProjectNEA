using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;
    public enum GameState // this is just to improve readability, and it also automatically assigns the values to them from 0 to n with it being incremented for each value.
    {
        Paused, // 0
        Playing, // 1
        DoubleSpeed,
        TripleSpeed
    }
    public GameState currentState = (GameState)0;
    bool hasGridBeenMade = false;
    GridTileSystem gridGenerator = new GridTileSystem(30, 50, 1f); // making the grid.
    // Start is called before the first frame update
    void Start()
    {
        
    }
     
    void Awake()
    {
        // singleton instance
        // it is literally just checking if an instance exists, and it is not this instance, then that instance deletes itself.
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
            DontDestroyOnLoad(this.gameObject); // makes sure this thing exists forever, even when scenes are loaded.
        }
    }
    void Update()
    {   
    if (!hasGridBeenMade && SceneManager.GetActiveScene().name == "MainGameScene")
    {
        gridGenerator.GenerateGrid();
        hasGridBeenMade = true;
    }

    if (SceneManager.GetActiveScene().name == "MainGameScene")
    {
        if (Input.GetKeyDown(KeyCode.Space))
            {
                switch(currentState)
                {
                    case 0:
                    currentState = (GameState)1;
                    break;

                    case (GameState)1:
                    currentState = 0;
                    break;

                    case (GameState)2:
                    currentState = 0;
                    break;

                    case (GameState)3:
                    currentState = 0;
                    break;
                }
            }
        if (Input.GetKeyDown(KeyCode.Tab))
            {
                switch(currentState)
                {
                    case 0:
                    currentState = (GameState)1;
                    break;

                    case (GameState)1:
                    currentState = (GameState)2;
                    break;

                    case (GameState)2:
                    currentState = (GameState)3;
                    break;

                    case (GameState)3:
                    currentState = (GameState)1;
                    break;
                }
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("You have pressed left click.");
            gridGenerator.DigFunction();
        }
    }
}