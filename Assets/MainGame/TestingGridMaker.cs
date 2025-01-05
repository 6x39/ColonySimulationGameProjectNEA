using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingGridMaker : MonoBehaviour
{
    GridTileSystem gridGenerator = new GridTileSystem(10, 5, 1f);
    // Start is called before the first frame update
    void Start()
    {
        gridGenerator.GenerateGrid();
    }
}
