using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class dragNdrop : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public towerScriptableObject towerSO;
    public projectileScriptableObject projectileSO;
    public GameObject towerPrefab;
    public gameScriptableObject gameSO;
    public GameObject coinTXT;
    private bool towerDragging;
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
        if (towerSO.cost <= gameSO.coins)
        {
            towerDragging = true;
            gameSO.coins -= towerSO.cost;

            coinTXT.GetComponentInChildren<TMP_Text>().text = string.Format("{0}", gameSO.coins);
            tower = Instantiate(towerPrefab, Vector3.zero, Quaternion.identity); //instantiate at 0,0,0.

            //IMPLEMENT COIN USAGE
            tower.GetComponent<towerManager>().towerSO = towerSO;
            tower.GetComponent<towerManager>().projectileSO = projectileSO;

            tower.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            Vector3 tmpPos = tower.transform.position; // Store all Vector3
            tmpPos.z = 0; // example assign individual fox Y axe
            tower.transform.position = tmpPos; // Assign back all Vector3

            // Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            // Debug.Log(tower);
        }
        else{
            print("too expensive");
        }

    }
    public void OnDrag(PointerEventData eventData)
    {
        if (towerDragging == true)
        {
            tower.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition); //update position of game object
            
            Vector3 tmpPos = tower.transform.position; // Store all Vector3
            tmpPos.z = 0; // example assign individual fox Y axe
            tower.transform.position = tmpPos; // Assign back all Vector3
        }

        
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        if (towerDragging == true)
        {
            StartCoroutine(Wait());
            towerDragging = false;
        }
        
    }
}

