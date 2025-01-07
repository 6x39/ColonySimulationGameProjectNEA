using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.Mathematics;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

// this current system means that whenever the game stops running, all of the objects will be destroyed too. therefore, this is not a permanent solution. I will need to implement a saving system that logs the position of each block and "saves" them more or less.
public class GridTileSystem : MonoBehaviour
{
    private int objectWidth; // number of blocks wide
    private int objectHeight; // number of blocks tall
    private float gapSize; // the gap between each block.
    GameObject prefabTile = (GameObject)Resources.Load("initialPrefabTile");// this is loading the prototype tile that is going to be used for the entire grid.

    public GridTileSystem(int width, int height, float gapSize)
    {
        this.objectWidth = width;
        this.objectHeight = height;
        this.gapSize = gapSize;
    }
    
    public void GenerateGrid()
    {
        for (int x = 0; x < objectWidth; x++)
        {
            for (int y = 0; y < objectHeight; y++)
            {
                Vector3 position = new Vector3((x * gapSize) + 0.5f, (y * gapSize) + 0.5f, 0);
                GameObject tile = Instantiate(prefabTile, position, quaternion.identity);   
                tile.name = $"tile_{x}_{y}";
            }
        }
    }
}
