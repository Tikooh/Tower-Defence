using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerManager : MonoBehaviour
{
    public towerScriptableObject towerSO;
    public projectileScriptableObject projectileSO;
    private int health;
    private int cost;
    private float cooldown;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<projectile>().projectileSO = projectileSO;
        gameObject.GetComponent<projectile>().projectilePrefab = towerSO.projectilePrefab;
        gameObject.GetComponent<DragNShoot2>().minPower = towerSO.minPower;
        gameObject.GetComponent<DragNShoot2>().maxPower = towerSO.maxPower;
        cost = towerSO.cost;
        health = towerSO.health;
        cooldown = towerSO.cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
