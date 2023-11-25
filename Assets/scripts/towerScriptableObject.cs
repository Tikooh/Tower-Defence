using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class towerScriptableObject : ScriptableObject
{
    public projectileScriptableObject projectileSO;
    public GameObject projectilePrefab;

    public int cost;
    public float cooldown;
    public int health;
    public Vector2 minPower;
    public Vector2 maxPower;
}

