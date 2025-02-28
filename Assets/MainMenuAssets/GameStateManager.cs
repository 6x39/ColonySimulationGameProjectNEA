using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;
    public enum GameState // this is just to improve readability, and it also automatically assigns the values to them from 0 to n with it being incremented for each value.
    {
        Paused, // 0
        Playing, // 1
        DoubleSpeed, // 2
        TripleSpeed // 3
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
        // getting all of the different characters. this is the easiest way to do it in my opinion.
        // I am not a fan of how poor this is, but I cannot find it elsewhere. If i were to put it in Start() then it would have to run on start which would be at the beginning of the game
        // being opened, so it would have literally no purpose. This is not worth it.
        // I will have to come up with a more elegant solution later. 
        GameObject c1 = GameObject.Find("Character1");
        GameObject c2 = GameObject.Find("Character2");
        GameObject c3 = GameObject.Find("Character3");
        if (!hasGridBeenMade && SceneManager.GetActiveScene().name == "MainGameScene")
        {   
            gridGenerator.GenerateGrid(); // generates the grid.
            if (c1 != null && c2 != null && c3 != null)
            {
                c1.transform.position = new Vector3(2, 0, -0.05f);
                c2.transform.position = new Vector3(0, 0, -0.05f); 
                c3.transform.position = new Vector3(-2, 0, -0.05f); // then changing all of the different characters' positions to be in the centre of the map
                c1.transform.localScale = new Vector3(1, 1.8f, 1);
                c2.transform.localScale = new Vector3(1, 1.8f, 1);
                c3.transform.localScale = new Vector3(1, 1.8f, 1); // then changing the sizes of the characters.
                Rigidbody2D rigidc1 = c1.GetComponent<Rigidbody2D>();
                Rigidbody2D rigidc2 = c2.GetComponent<Rigidbody2D>();
                Rigidbody2D rigidc3 = c3.GetComponent<Rigidbody2D>(); // this is then grabbing the rigidbodies from each of them.
                rigidc1.constraints = ~(RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY);
                rigidc2.constraints = ~(RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY);
                rigidc3.constraints = ~(RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY); // unfreezes the characters. 
                rigidc1.AddForce(new Vector2(0.1f, 0));
                rigidc2.AddForce(new Vector2(0.1f, 0));
                rigidc3.AddForce(new Vector2(0.1f, 0)); // this is to make it move after being unfrozen. 
            }

            hasGridBeenMade = true; // makes sure it doesn't get generated again.
        }

        // This stuff below is for all of the camera movement, zooming and game state changes. I am going to add some other pieces of code probably for the movement of each individual character. 

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
            // this code should be changed slightly in the future anyways, I do not like how whenever you left click it will use the dig function.
            // what I might do is if you are in a specific mode (digging mode) then it will allow you to dig, else it will just bring up the statistics of said object.
            // This should be a better solution and is what I intended to do in the future anyways. 
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

        // making sure these objects exist before you even try to do anything with them.
        if (c1 != null && c2 != null && c3 != null) 
        {
            // I should change this to meet the same code as my camera movement perhaps.
            // I also need to change the "friction" or "air resistance" so the objects actually slow down when you stop holding it down when the game speed is higher.
            // I will just change how to the game speed stuff works slightly.
            
            // and this code needs to be altered in a way that prevents constantly moving upwards. I want them to be able to go diagonally (so they don't just have to go up or just to the side)
            // but that will mean I also need to prevent them from moving upwards if they're in the air already.
            // maybe if i look for if it is colliding with a tile, and if it is then it can jump, else it can't? That would work.
            
            // for now the up and left or up and right will just go left and right respectively until i think of a fix. 

            if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow))
            {
                c1.GetComponent<Rigidbody2D>().velocity = new Vector2(-3f * (int)currentState, c1.GetComponent<Rigidbody2D>().velocity.y);
            }
            else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
            {
                c1.GetComponent<Rigidbody2D>().velocity = new Vector2(3f * (int)currentState, c1.GetComponent<Rigidbody2D>().velocity.y);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                c1.GetComponent<Rigidbody2D>().velocity = new Vector2(-3f * (int)currentState, c1.GetComponent<Rigidbody2D>().velocity.y);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if ((int)currentState != 0) c1.GetComponent<Rigidbody2D>().velocity = new Vector2(c1.GetComponent<Rigidbody2D>().velocity.x, 5);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                c1.GetComponent<Rigidbody2D>().velocity = new Vector2(3f * (int)currentState, c1.GetComponent<Rigidbody2D>().velocity.y);
            }
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

