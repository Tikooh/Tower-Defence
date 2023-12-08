using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class coinPickup : MonoBehaviour
{
    public gameScriptableObject gameSO;
    // Start is called before the first frame updat
    void OnMouseOver()
    {
        if (gameObject.CompareTag("coin"))
        {
            gameSO.coinPickup();
            Destroy(gameObject);
        }
    }
}
