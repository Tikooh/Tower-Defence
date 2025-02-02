using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class enemyScriptableObject : ScriptableObject
{
    public int health;
    public int damage;
    public float cooldown;
    public bool canDeflect; 
    public float speed;
    public GameObject onDeathPrefab;
    public GameObject coinPrefab;
}

