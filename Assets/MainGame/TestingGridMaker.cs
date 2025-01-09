using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingGridMaker : MonoBehaviour
{
    // Start is called before the first frame update
    GridTileSystem gridGenerator = new GridTileSystem(10, 5, 1f);
    void Start()
    {
        gridGenerator.GenerateGrid();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gridGenerator.DigFunction();
        }
    }
}
