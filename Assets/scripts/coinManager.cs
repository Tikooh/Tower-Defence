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

    private IEnumerator moneyOverTime()
    {
        while (gameSO.health > 0)
        {
            gameSO.coinPickup();
            yield return new WaitForSeconds(5);
        }

    }
    void Start()
    {
        print(gameSO.coins);
        coinTXT.GetComponentInChildren<TMP_Text>().text = string.Format("{0}", gameSO.coins);
        gameSO.coinPickupEvent.AddListener(updateCoinTXT);
        StartCoroutine(moneyOverTime());
    }
    void updateCoinTXT()
    {
        coinTXT.GetComponentInChildren<TMP_Text>().text = string.Format("{0}", gameSO.coins);
    }
}
