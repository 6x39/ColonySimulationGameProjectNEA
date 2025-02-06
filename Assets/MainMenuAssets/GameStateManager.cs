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
    GridTileSystem gridGenerator = new GridTileSystem(50, 76, 1f, new(-25, -38)); // making the grid.
    float cameraSpeed = 1f;

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

        if (Input.GetAxisRaw("Mouse ScrollWheel") < 0f ) // forward
        {
            if (Camera.main.orthographicSize + 0.5f != 10) Camera.main.orthographicSize += 0.5f;
            cameraSpeed = 1 + (Camera.main.orthographicSize * 0.3f);
        }
        else if (Input.GetAxisRaw("Mouse ScrollWheel") > 0f ) // backwards 
        {
            if (Camera.main.orthographicSize + 0.5f != 1) Camera.main.orthographicSize -= 0.5f;
            cameraSpeed = 1 + (Camera.main.orthographicSize * 0.3f);
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            CameraMovement("up and left");
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            CameraMovement("up and right");
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            CameraMovement("down and left");
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            CameraMovement("down and right");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            CameraMovement("right");
        }
        else if (Input.GetKey(KeyCode.A))
        {
            CameraMovement("left");
        }
        else if (Input.GetKey(KeyCode.W))
        {
            CameraMovement("up");
        }
        else if (Input.GetKey(KeyCode.S))
        {
            CameraMovement("down");
        }

        // seperate if statement for checking if scrolling is happening. this is so you can scroll AND move at the same time (hopefully).
    }   


    public void CameraMovement(string direction) // this is going to allow the user to control the camera. To make it actually visible that the camera is moving, I will need to change the sprite of the tiles to have an outline.
    {
        switch(direction) // this is going to be for the direction that the camera is moving. 
        {
            case "left":
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x - (0.1f * cameraSpeed), Camera.main.transform.position.y, Camera.main.transform.position.z);
            break;

            case "right":
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x + (0.1f * cameraSpeed), Camera.main.transform.position.y, Camera.main.transform.position.z);
            break;

            case "down":
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y - (0.1f * cameraSpeed) , Camera.main.transform.position.z);
            break;

            case "up":
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y + (0.1f * cameraSpeed) , Camera.main.transform.position.z);
            break;

            case "up and left":
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x - (0.1f * cameraSpeed), Camera.main.transform.position.y + (0.1f * cameraSpeed), Camera.main.transform.position.z);
            break;

            case "up and right":
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x + (0.1f * cameraSpeed), Camera.main.transform.position.y + (0.1f * cameraSpeed), Camera.main.transform.position.z);
            break;

            case "down and left":
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x - (0.1f * cameraSpeed), Camera.main.transform.position.y - (0.1f * cameraSpeed), Camera.main.transform.position.z);
            break;

            case "down and right":
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x + (0.1f * cameraSpeed), Camera.main.transform.position.y - (0.1f * cameraSpeed), Camera.main.transform.position.z);
            break;
        }
    }
}