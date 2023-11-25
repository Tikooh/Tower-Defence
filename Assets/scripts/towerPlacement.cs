using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.EventSystems;

public class towerPlacement : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Here");
        if (gameObject.tag == "towerPlaceable")
        {
            Debug.Log("onpointerdwon");
            gameObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector3 tmpPos = gameObject.transform.position; // Store all Vector3
            tmpPos.z = 0; // example assign individual fox Y axe
            gameObject.transform.position = tmpPos; // Assign back all Vector3
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (gameObject.tag == "towerPlaceable")
        {
            Debug.Log("OnDrag");
            gameObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector3 tmpPos = gameObject.transform.position; // Store all Vector3
            tmpPos.z = 0; // example assign individual fox Y axe
            gameObject.transform.position = tmpPos; // Assign back all Vector3
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (gameObject.tag == "towerPlaceable")
        {
            gameObject.tag = "tower";
        }
    }
}
