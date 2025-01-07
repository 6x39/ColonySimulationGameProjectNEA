using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingGridMaker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GridTileSystem gridGenerator = new GridTileSystem(10, 5, 1f);
        gridGenerator.GenerateGrid();
    }
}
