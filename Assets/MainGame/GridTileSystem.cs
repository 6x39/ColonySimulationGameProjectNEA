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

    public GridTileSystem(int width, int height, float gapSize)
    {
        this.objectWidth = width;
        this.objectHeight = height;
        this.gapSize = gapSize;
    }
    
    public void GenerateGrid()
    {
        GameObject prefabTile = (GameObject)Resources.Load("initialPrefabTile");
        GameObject TileHolder = GameObject.Find("TileHolder");
        for (int x = 0; x < objectWidth; x++)
        {
            for (int y = 0; y < objectHeight; y++)
            {
                Vector2 position = new Vector2((x * gapSize) + 0.5f, (y * gapSize) + 0.5f);
                GameObject tile = Instantiate(prefabTile, position, Quaternion.identity);   
                tile.name = $"tile_{x}_{y}";
                tile.transform.parent = TileHolder.transform;
                tile.AddComponent(typeof(BoxCollider2D));
            }
        }
    }
    
    public void DigFunction() // this will be repurposed at a later day for my mechanics.
    {
        Vector3 cursorPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        Vector3 worldCursorPosition = Camera.main.ScreenToWorldPoint(cursorPosition);
        Debug.Log(worldCursorPosition);
        LayerMask mask = LayerMask.GetMask("Default");
        Collider2D intersecting = Physics2D.OverlapCircle(worldCursorPosition, 0.1f, mask);
        Debug.Log(intersecting);
        if (intersecting != null)
        {
            Destroy(intersecting);
        }
    }
}
