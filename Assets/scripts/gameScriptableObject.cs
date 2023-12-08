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
    [System.NonSerialized] public UnityEvent gameOverEvent;
    [System.NonSerialized] public UnityEvent pauseEvent;
    [System.NonSerialized] public UnityEvent unpauseEvent;
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

        if (gameOverEvent == null)
        {
            gameOverEvent = new UnityEvent();
        }

        if (pauseEvent == null)
        {
            pauseEvent = new UnityEvent();
        }

        if (unpauseEvent == null)
        {
            unpauseEvent = new UnityEvent();
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

    public void healthZero()
    {
        gameOverEvent.Invoke();
    }

    public void Pause()
    {
        pauseEvent.Invoke();
    }
    
    public void Unpause()
    {
        unpauseEvent.Invoke();
    }
}
