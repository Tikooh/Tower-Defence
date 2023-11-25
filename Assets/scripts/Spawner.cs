using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public enemyScriptableObject[] enemySO;
    public float spawnTime;
    private float timer;
    public enum enemyType
    {
        slow,
        fast,
        shield,
        deflector,
        boss

    }



    // Start is called before the first frame update
    void Start()
    {
        timer = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer<= 0)
        {
            spawnEnemy();
        }
    }

    void spawnEnemy()
    {
        GameObject enemy = Instantiate (enemyPrefab[0], transform.position, Quaternion.Euler(0,180f,0));

        enemy.GetComponent<enemyController>().enemySO = enemySO[0];

        timer = spawnTime;
    }
}
