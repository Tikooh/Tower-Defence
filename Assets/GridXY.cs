using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridXY
{
    int width;
    int height;
    
    public GridXY(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    public void constructGrid()
    {
        int posX = 0;
        int posY = 0;
        // List<GridObject> list = new List<GridObject>;
        for (int i = 0; i <= width; i++)
        {
            posX += 50;
            for (int j = 0; j <= height; j++)
            {
                posY += 50;
                // list.Add(GridObject(posX,posY));
            }
        }
    }
}

public class GridObject
{
    int posX;
    int posY;

    public GridObject(int posX, int posY)
    {
        this.posX = posX;
        this.posY = posY;
    }
}