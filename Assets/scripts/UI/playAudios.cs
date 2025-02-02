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
    public AudioClip bossDefeat;
    public AudioClip enemyDefeat;
    // Start is called before the first frame update
    void Start()
    {
        gameSO.coinPickupEvent.AddListener(coinPickupSFX);
        gameSO.healthChangeEvent.AddListener(baseHitSFX);
        gameSO.enemyDefeatedEvent.AddListener(enemySFX);
        gameSO.bossDefeatedEvent.AddListener(bossSFX);
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

    void enemySFX()
    {
        audioSource.PlayOneShot(enemyDefeat);
    }

    void bossSFX()
    {
        audioSource.PlayOneShot(bossDefeat);
    }
}
