using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class cardScriptableObject : ScriptableObject
{
    public Texture towerIcon;
    public towerScriptableObject towerSO;
    public projectileScriptableObject projectileSO;
    public GameObject towerPrefab;
    public int cost;
}
