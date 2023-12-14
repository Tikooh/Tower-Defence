using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class test : MonoBehaviour
{
    public GameObject sukonbu;
    public int xOffset;
    public int yOffset;
    public GridXY grid;
    private Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        grid = new GridXY(14,6,20f, () => new GridTile());

        position = new Vector3(0-1.6f,0-0.2f,0);
        GameObject gridPrefab = Instantiate(sukonbu, position, Quaternion.identity);
        gridPrefab.SetActive(false);
        gridPrefab.tag = "grid";
        staticTest.go = gridPrefab;



        // Debug.Log(grid.gridArray[0,0]);
        for (int x=0; x < grid.gridArray.GetLength(0);x++)
        {
            for (int y=0; y<grid.gridArray.GetLength(1);y++)
            {
                position = new Vector3(x+xOffset,y+yOffset,0);
                GridTile tile = grid.gridArray[x,y];
                tile.position = position;
                tile.tower = sukonbu;
                Debug.Log(tile.position);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
