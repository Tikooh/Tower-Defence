using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class enemyScriptableObject : ScriptableObject
{
    [System.NonSerialized]
    public int health;
    
    [SerializeField]
    private int maxHealth;
    
    public int damage;
    public float cooldown;
    public bool canDeflect; 
    public GameObject onDeathPrefab;

    public UnityEvent healthChangeEvent;

    private void OnEnable()
    {
        health = maxHealth;
        if (healthChangeEvent == null)
        {
            healthChangeEvent = new UnityEvent();
        }
    }

    public void DecreaseHealth(int amount)
    {
        health -= amount;
        healthChangeEvent.Invoke();
    }
}

