using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class dragNdrop : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public towerScriptableObject towerSO;
    public projectileScriptableObject projectileSO;
    public GameObject towerPrefab;
    GameObject tower;

    private IEnumerator Wait()
    {
        // Debug.Log("waiting");
        yield return new WaitForSeconds(0.2f);
        tower.tag = "Throwable";

    }
    public void OnPointerDown(PointerEventData eventData)
    {   
        // Debug.Log("OnDrop");
        // Debug.Log(towerSprite);
        tower = Instantiate(towerPrefab, Vector3.zero, Quaternion.identity); //instantiate at 0,0,0.
        tower.GetComponent<towerManager>().towerSO = towerSO;
        tower.GetComponent<towerManager>().projectileSO = projectileSO;

        tower.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        Vector3 tmpPos = tower.transform.position; // Store all Vector3
        tmpPos.z = 0; // example assign individual fox Y axe
        tower.transform.position = tmpPos; // Assign back all Vector3

        // Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        // Debug.Log(tower);
    }
    public void OnDrag(PointerEventData eventData)
    {

        tower.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition); //update position of game object
        
        Vector3 tmpPos = tower.transform.position; // Store all Vector3
        tmpPos.z = 0; // example assign individual fox Y axe
        tower.transform.position = tmpPos; // Assign back all Vector3
        
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        StartCoroutine(Wait());
    }
}

