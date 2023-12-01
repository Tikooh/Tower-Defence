using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class gameHealthScriptableObject : ScriptableObject
{
    [System.NonSerialized]
    public int health;

    [SerializeField]
    public int maxHealth;

    public UnityEvent healthChangeEvent;
    private void OnEnable()
    {
        health = maxHealth;
        if (healthChangeEvent == null)
        {
            healthChangeEvent = new UnityEvent();
        }
    }

    public void decreaseHealth(int amount)
    {
        health -= amount;
        healthChangeEvent.Invoke();
    }

}
