using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class playAudios : MonoBehaviour
{
    public gameScriptableObject gameSO;
    public AudioSource audioSource;
    public AudioClip coin;
    public AudioClip baseHit;
    // Start is called before the first frame update
    void Start()
    {
        gameSO.coinPickupEvent.AddListener(coinPickupSFX);
        gameSO.healthChangeEvent.AddListener(baseHitSFX);
    }

    void coinPickupSFX()
    {
        audioSource.PlayOneShot(coin);
        Debug.Log("Playing Coin sound");
    }

    void baseHitSFX()
    {
        audioSource.PlayOneShot(baseHit);
    }
}
