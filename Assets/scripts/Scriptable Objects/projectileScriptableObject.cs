using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu]
public class projectileScriptableObject : ScriptableObject
{
    public int pierce;
    public bool isMelee;
    public int speed;
    public int damage;
    public int cooldown;
    public float radius;
    public GameObject onDeathPrefab;
    public projectileScriptableObject onDeathSO;
}
