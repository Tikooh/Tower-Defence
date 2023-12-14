using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class towerCardManager : MonoBehaviour
{

    [Header("Cards Parameters")]
    public int amtOfCards;
    public cardScriptableObject[] CardSO;
    public GameObject cardPrefab;
    public Transform cardHolderTransform;

    [Header("Tower Parameters")]
    public GameObject[] towerCards;
    
    public float cooldown;
    public int cost;
    public Texture towerIcon;
    public gameScriptableObject gameSO;
    public GameObject coinTXT;

    private void Start()
    {
        towerCards = new GameObject[amtOfCards];

        for (int i = 0; i < amtOfCards; i++)
        {
            AddTowerCard(i);
        }
    }

    public void AddTowerCard(int index)
    {
        GameObject card = Instantiate(cardPrefab, cardHolderTransform);

        dragNdrop dragNdrop = card.GetComponent<dragNdrop>();
        
        dragNdrop.towerSO = CardSO[index].towerSO;
        dragNdrop.projectileSO = CardSO[index].projectileSO;
        dragNdrop.towerPrefab = CardSO[index].towerPrefab;
        dragNdrop.gameSO = gameSO;
        dragNdrop.coinTXT = coinTXT;

        // Debug.Log(dragNdrop.towerSprite);
        towerCards[index] = card;

        towerIcon = CardSO[index].towerIcon;
        cost = CardSO[index].cost;

        card.GetComponentInChildren<RawImage>().texture = towerIcon;
        card.GetComponentInChildren<TMP_Text>().text = "" + cost;
    }

    
    
}
