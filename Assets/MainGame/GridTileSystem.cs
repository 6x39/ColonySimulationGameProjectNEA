using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.Mathematics;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

// this current system means that whenever the game stops running, all of the objects will be destroyed too. therefore, this is not a permanent solution. I will need to implement a saving system that logs the position of each block and "saves" them more or less.
public class GridTileSystem : MonoBehaviour
{
    private int objectWidth; // number of blocks wide
    private int objectHeight; // number of blocks tall
    private float blockSize; // the width and height of each block
    private int[,] gridArray; // the array for each block in the grid. and essentially their positions.
    GameObject prefabTile; // this is loading the prototype tile that is going to be used for the entire grid.

    void Start()
    {
        prefabTile = (GameObject)Resources.Load("initialPrefabTile");
        if (prefabTile != null)
        {
            Debug.Log("PrefabTile is not null");
        }
        else
        {
            Debug.Log("The problem is something else lol");
        }
    }

    public GridTileSystem(int width, int height, float blockSize)
    {
        this.objectWidth = width;
        this.objectHeight = height;
        this.blockSize = blockSize;

        gridArray = new int[width, height];
    }
    public void GenerateGrid()
    {
        for (int x = 0; x < this.objectWidth; x++)
        {
            for (int y = 0; y < this.objectHeight; y++)
            {
                Vector3 position = new Vector3(x * this.blockSize, y * this.blockSize, 0);
                GameObject tile = Instantiate(prefabTile, position, quaternion.identity);   
                tile.name = $"tile_{x}_{y}";
            }
        }
    }
}

