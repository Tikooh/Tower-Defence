using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerManager : MonoBehaviour
{
    public towerScriptableObject towerSO;
    public projectileScriptableObject projectileSO;
    public int health;
    private int maxHealth;
    private int cost;
    private float cooldown;
    private bool flashing;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<projectile>().projectileSO = projectileSO;
        gameObject.GetComponent<projectile>().projectilePrefab = towerSO.projectilePrefab;
        gameObject.GetComponent<DragNShoot2>().minPower = towerSO.minPower;
        gameObject.GetComponent<DragNShoot2>().maxPower = towerSO.maxPower;
        gameObject.GetComponent<DragNShoot2>().collisions = towerSO.collisions;
        cost = towerSO.cost;
        health = towerSO.health;
        maxHealth = health;
        cooldown = towerSO.cooldown;
    }

    private IEnumerator Flash()
    {
        while (true)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            yield return new WaitForSeconds(1f);
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(1f);
        }


    }
    void FixedUpdate()
    {
        // switch ((float) health)
        // {
        //     case float n when n <= (float) maxHealth * 0.4:
        //         gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        //         break;

        //     case float n when n <= 0f:
        //         Destroy(gameObject);
        //         break;
        // }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
        if ((float) health <= (float) maxHealth * 0.4f)
        {
            if (!flashing)
            {
                StartCoroutine(Flash());
                flashing = true;
            }
            
        }
    }

}
