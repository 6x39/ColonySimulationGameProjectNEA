using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.Mathematics;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.Tilemaps;

// this current system means that whenever the game stops running, all of the objects will be destroyed too. therefore, this is not a permanent solution. I will need to implement a saving system that logs the position of each block and "saves" them more or less.
public class GridTileSystem : MonoBehaviour
{
    private int objectWidth; // number of blocks wide
    private int objectHeight; // number of blocks tall
    private float gapSize; // the gap between each block
    private Vector2 origin; // this is where the origin is going to be (where the grid starts).

    public GridTileSystem(int width, int height, float gapSize, Vector2 origin)
    {
        this.objectWidth = width;
        this.objectHeight = height;
        this.gapSize = gapSize;
        this.origin = origin;
    }
    
    public void GenerateGrid() // 
    {
        GameObject prefabTile = (GameObject)Resources.Load("initialPrefabTile");
        GameObject TileHolder = GameObject.Find("TileHolder");
        for (int x = 0; x < objectWidth; x++) // finds the x coordinate of the gameobject to be generated
        {
            for (int y = 0; y < objectHeight; y++) // finds the y coordinate of the gameobject to be generated
            {
                Vector2 position = new Vector2((x * gapSize) + 0.5f, (y * gapSize) + 0.5f) + origin;
                if (position.x >= -4 && position.x <= 4 && position.y >= -1 && position.y <= 2) // if the position is in the unwanted range. 
                {
                    continue; // because we do not want to run the grid code. 
                }
                else
                { // creates the game object at the point of origin 

                GameObject tile = Instantiate(prefabTile, position, Quaternion.identity);   
                tile.name = $"tile_{x}_{y}"; // names the gameobject
                tile.transform.parent = TileHolder.transform;
                tile.AddComponent(typeof(BoxCollider2D)); // gives the gameobject a collider
                // tile.AddComponent(typeof(Rigidbody2D)); // gives the gameobject a rigidbody
                // Rigidbody2D rb = tile.GetComponent<Rigidbody2D>();
                // rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY; // freezes the tiles.
                BoxCollider2D bc = tile.GetComponent<BoxCollider2D>(); // unused for now, but just gets the rigidbody component of each tile.
                }
            }
        }
    }
    
    public void DigFunction() // this will be repurposed at a later day for my mechanics. but for now it will just delete the gameobject that is being clicked on.
    {
        Vector3 cursorPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0); // finds the position of the cursor on the screen
        Vector3 worldCursorPosition = Camera.main.ScreenToWorldPoint(cursorPosition); // and then converts it to a world vector instead.
        LayerMask mask = LayerMask.GetMask("Default"); // unneeded, but tells the OverlapCircle which layer to work on.
        Collider2D intersecting = Physics2D.OverlapCircle(worldCursorPosition, 0.001f, mask); // finds the collider that is intersecting with the cursor.
        if (intersecting != null) // if there is a gameobject there 
        {
            Destroy(intersecting.gameObject); // then destroys it
        }
    }

    public void BuildFunction(string objectToUse) // this will allow for doing the reverse of the dig function essentially. I'm gonna make sure there is no object there and if there isn't then it will build.
    // I can probably just make the same code as above but move the if statement.
    {
        // I will need to check the position of the cursor
        // find the x value and y value of the cursor
        // place an object there.
        // not adding comments to all of the next things adding information on them, as that's already listed above. 
        Vector3 cursorPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        Vector3 worldCursorPosition = Camera.main.ScreenToWorldPoint(cursorPosition); 
        LayerMask mask = LayerMask.GetMask("Default"); 
        Collider2D intersecting = Physics2D.OverlapCircle(worldCursorPosition, 0.001f, mask);
        GameObject prefabTile = (GameObject)Resources.Load(objectToUse);
        GameObject TileHolder = GameObject.Find("TileHolder");
        if (intersecting == null) // if there is no gameobject there
        {
            // run the code that builds the object.
            //Vector3 placeToPutObject =  new Vector3((float)Math.Truncate(worldCursorPosition.x) + 0.5f, (float)Math.Truncate(worldCursorPosition.y) + 0.5f, 0);
            Vector3 placeToPutObject =  new Vector3(Mathf.Floor(worldCursorPosition.x) + 0.5f, Mathf.Floor(worldCursorPosition.y) + 0.5f, 0);
            GameObject tile = Instantiate(prefabTile, placeToPutObject, Quaternion.identity);   
            tile.name = $"tile_{(float)Math.Truncate(worldCursorPosition.x)}_{(float)Math.Truncate(worldCursorPosition.y)}"; // names the gameobject
            tile.transform.parent = TileHolder.transform;
            tile.AddComponent(typeof(BoxCollider2D)); // gives the gameobject a collider
        }
    }
}
