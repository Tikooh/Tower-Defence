using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.EventSystems;

public class towerPlacement : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private GridXY grid;
    private Vector3 pos;
    private Vector3 relativeCameraPos;

    void Start()
    {
        grid = GameObject.FindGameObjectWithTag("gridManager").GetComponent<test>().grid;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Here");
        if (gameObject.tag == "towerPlaceable")
        {
            staticTest.go.SetActive(true);

            Debug.Log("onpointerdwon");

            relativeCameraPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (relativeCameraPos.x <= 4f && relativeCameraPos.x >= -10f && relativeCameraPos.y >= -3f && relativeCameraPos.y <= 3f)
            {

                Vector3 CompPos = new Vector3((int) Math.Floor(relativeCameraPos.x), (int) Math.Floor(relativeCameraPos.y), 0);
                
                foreach (GridTile i in grid.gridArray)
                {
                    if (i.position == CompPos)
                    {
                        i.towerPlaced = true;
                        pos = i.position;
                    }
                }

                gameObject.transform.position = pos;
            }
            else{
                gameObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 tmpPos = gameObject.transform.position; // Store all Vector3
                tmpPos.z = 0; // example assign individual fox Y axe
                gameObject.transform.position = tmpPos; // Assign back all Vector3
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (gameObject.tag == "towerPlaceable")
        {
            // Debug.Log("OnDrag");
            relativeCameraPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            int x = (int) Math.Floor(relativeCameraPos.x);
            int y = (int) Math.Floor(relativeCameraPos.y);

            // Debug.Log(String.Format("x:{0}, y:{1}", x, y));


            if (x <= 4 && x >= -10)
            {

                if ( y >= -3 && y <= 3)
                {

                    Vector3 CompPos = new Vector3(x, y, 0);
                    // Debug.Log(CompPos);
                    print(grid.gridArray[0,0]);
                    
                    foreach (GridTile i in grid.gridArray)
                    {
                        if (i.position == CompPos)
                        {
                            // Debug.Log(String.Format("position:{0}, CompPos:{1}", i.position, CompPos));

                            i.towerPlaced = true;
                            pos = new Vector3((float) i.position.x + -0.1f, (float) i.position.y + 0.4f, 0);
                            gameObject.transform.position = pos;
                        }
                    }

                    
                }

            }

            else{
                // Debug.Log(String.Format("mouse:{0}, pos:{1}", relativeCameraPos, pos));

                gameObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 tmpPos = gameObject.transform.position; // Store all Vector3
                tmpPos.z = 0; // example assign individual fox Y axe
                gameObject.transform.position = tmpPos; // Assign back all Vector3
            }

        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (gameObject.tag == "towerPlaceable")
        {
            gameObject.tag = "tower";
            GameObject.FindGameObjectWithTag("grid").SetActive(false);
        }
    }
}
