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
    private int maxHealth;

    public UnityEvent healthChangeEvent;

}
