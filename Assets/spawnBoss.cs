using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class spawnBoss : MonoBehaviour
{
    public waveScriptableObject waveSO;
    public enemyScriptableObject enemySO;
    public GameObject bossPrefab;
    public GameObject timer;
    private bool hasSpawned;

    void Start()
    {
        hasSpawned = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (timer.GetComponent<timer>().timeElapsed >= waveSO.bossWaveTime && !hasSpawned)
        {
            GameObject enemy = Instantiate (bossPrefab, transform.position, Quaternion.Euler(0,180f,0));

            enemy.GetComponent<enemyController>().enemySO = enemySO;
            hasSpawned = true;
        }
    }
}
