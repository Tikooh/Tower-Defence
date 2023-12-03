using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public enemyScriptableObject enemySO;
    private GameObject onDeathPrefab;
    public int health;
    public int damage;
    public Rigidbody2D rb;
    public int hitDelay = 1;
    private bool isHit = false;
    private float timer;
    public GameObject coinPrefab;
    [SerializeField] public Vector2 force;

    // Start is called before the first frame update
    void Start()
    {
        timer = hitDelay;
        health = enemySO.health;
        damage = enemySO.damage;
        onDeathPrefab = enemySO.onDeathPrefab;
        coinPrefab = enemySO.coinPrefab;
    }

    private IEnumerator Flash()
    {
        // Debug.Log("waiting");
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Throwable")
        {
            if (collision.gameObject.GetComponent<DragNShoot2>().rb.velocity.x > 0)
            {
                Destroy(gameObject);
                Instantiate(onDeathPrefab, transform.position, Quaternion.identity);
                Debug.Log("killed");
            }

            if (collision.gameObject.GetComponent<DragNShoot2>().rb.velocity.y > 0)
            {
                force = new Vector2(force.x, force.y);
            }
            else if (collision.gameObject.GetComponent<DragNShoot2>().rb.velocity.y < 0)
            {
                force = new Vector2(force.x, -force.y);
            }
            collision.gameObject.GetComponent<DragNShoot2>().rb.velocity -= force;
            
            // Debug.Log("Collision");
        }
        if (collision.gameObject.tag == "projectile" && isHit == false)
        {
            StartCoroutine(Flash());
            health -= collision.gameObject.GetComponent<projectileManager>().damage;

            isHit = true;
            if (health <= 0)
            {
                Destroy(gameObject);
                Instantiate(onDeathPrefab, transform.position, Quaternion.identity);
                Instantiate(coinPrefab, transform.position, Quaternion.identity);
            }

        }
        
    }
    void Update()
    {
        if (isHit == true)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                isHit = false;
            }
        }
    }
}
