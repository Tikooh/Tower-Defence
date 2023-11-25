using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileManager : MonoBehaviour
{
    public projectileScriptableObject projectileSO;
    private int power;
    private bool isMelee;
    private int speed;
    public int damage;
    private int cooldown;
    private float radius;
    private GameObject onDeathPrefab;
    // Start is called before the first frame update
    void Start()
    {
        power = projectileSO.power;
        isMelee = projectileSO.isMelee;
        gameObject.GetComponent<projectileMovement>().speed = projectileSO.speed;
        damage = projectileSO.damage;
        cooldown = projectileSO.cooldown;
        radius = projectileSO.radius;
        onDeathPrefab = projectileSO.onDeathPrefab;

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && radius > 0)
        {
            Destroy(gameObject);
            Instantiate(onDeathPrefab, transform.position, Quaternion.identity);
            

        }
        if (collision.gameObject.tag == "backboard")
        {
            Destroy(gameObject);
        }
    }



}
