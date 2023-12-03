using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class gameScriptableObject: ScriptableObject
{
    [System.NonSerialized]
    public int health;

    [SerializeField]
    public int maxHealth;

    [System.NonSerialized]
    public int coins;

    public UnityEvent healthChangeEvent;
    public UnityEvent coinPickupEvent;
    private void OnEnable()
    {

        // HEALTH
        health = maxHealth;
        if (healthChangeEvent == null)
        {
            healthChangeEvent = new UnityEvent();
        }

        coins = 0;
        if (coinPickupEvent == null)
        {
            coinPickupEvent = new UnityEvent();
        }
    }

    public void coinPickup()
    {
        coins += 10;
        coinPickupEvent.Invoke();
    }
    //HEALTH
    public void decreaseHealth(int amount)
    {
        health -= amount;
        healthChangeEvent.Invoke();
    }

}
