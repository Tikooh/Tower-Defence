using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GridXY
{
    int width;
    int height;
    private float cellSize;
    public GridTile[,] gridArray;
    
    //arrays are static and cannot be changed
    // private int[,] gridArray creates a multidimensional array
    public GridXY(int width, int height, float cellSize, Func<GridTile> createGridObject)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        gridArray = new GridTile[width, height];


        for (int x=0; x < gridArray.GetLength(0); x++)
        {
            for (int y=0; y < gridArray.GetLength(1); y++)
            {
                gridArray[x,y] = createGridObject();

            }
        }
    }
}


public class GridTile
{
    public Vector3 position;
    public bool towerPlaced {get; set; }
    public GameObject tower {get; set;}
    
}