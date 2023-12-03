using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class coinManager : MonoBehaviour
{
    public gameScriptableObject gameSO;
    public GameObject coinTXT;
    // Start is called before the first frame update
    void Start()
    {
        gameSO.coinPickupEvent.AddListener(updateCoinTXT);
    }
    void updateCoinTXT()
    {
        coinTXT.GetComponentInChildren<TMP_Text>().text = string.Format("{0}", gameSO.coins);
    }
}
