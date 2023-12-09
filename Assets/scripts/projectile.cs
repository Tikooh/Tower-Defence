using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public projectileScriptableObject projectileSO;
    public GameObject projectilePrefab;

    private float timer;
    
    void Start()
    {
        timer = projectileSO.cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "tower")
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                spawnProjectile();
                
            }

        }
    }


    void spawnProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        projectile.GetComponent<projectileManager>().projectileSO = projectileSO;

        if (projectileSO.isMelee == true)
        {
            Debug.Log("true");
            projectile.GetComponent<meleeDestroy>().isMelee = true;
        }
        timer = projectileSO.cooldown;
    }
}