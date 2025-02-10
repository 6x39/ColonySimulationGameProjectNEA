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
                tile.AddComponent(typeof(Rigidbody2D)); // gives the gameobject a rigidbody
                // Rigidbody2D rb = tile.GetComponent<Rigidbody2D>();
                BoxCollider2D bc = tile.GetComponent<BoxCollider2D>(); // unused for now, but just gets the rigidbody component of each tile.
                // rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY; // freezes the tiles.
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
}
