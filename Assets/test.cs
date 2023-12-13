using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class test : MonoBehaviour
{
    public GameObject sukonbu;
    // Start is called before the first frame update
    void Start()
    {
        GridXY grid = new GridXY(10,10,20f, () => new GridTile());


        // Debug.Log(grid.gridArray[0,0]);
        for (int x=0; x < grid.gridArray.GetLength(0);x++)
        {
            for (int y=0; y<grid.gridArray.GetLength(1);y++)
            {
                Vector2 position = new Vector2(x,y);
                GridTile tile = grid.gridArray[x,y];
                tile.position = position;
                tile.tower = sukonbu;

                Instantiate(tile.tower, tile.position, Quaternion.identity);
                Debug.Log(grid.gridArray[x,y].position);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
