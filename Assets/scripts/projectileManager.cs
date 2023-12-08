using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileManager : MonoBehaviour
{
    public projectileScriptableObject projectileSO;

    [System.NonSerialized]
    public int pierce;
    private bool isMelee;
    private int speed;
    public int damage;
    private int cooldown;
    private float radius;
    [System.NonSerialized]
    public GameObject onDeathPrefab;
    public projectileScriptableObject onDeathSO;
    // Start is called before the first frame update
    void Start()
    {
        pierce = projectileSO.pierce;
        isMelee = projectileSO.isMelee;
        gameObject.GetComponent<projectileMovement>().speed = projectileSO.speed;
        damage = projectileSO.damage;
        cooldown = projectileSO.cooldown;
        radius = projectileSO.radius;
        onDeathPrefab = projectileSO.onDeathPrefab;
        onDeathSO = projectileSO.onDeathSO;

    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "backboard")
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (pierce <= 0)
        {
            if (gameObject.CompareTag("explosive"))
            {
                GameObject explosion = Instantiate(onDeathPrefab, transform.position, Quaternion.identity);
                explosion.GetComponent<projectileManager>().projectileSO = onDeathSO;

            }
            Destroy(gameObject);
        }

    }

}
