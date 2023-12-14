using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class enemyController : MonoBehaviour
{
    public enemyScriptableObject enemySO;
    public gameScriptableObject gameSO;
    private GameObject onDeathPrefab;
    public int health;
    public int damage;
    public Rigidbody2D rb;
    public float hitDelay = 1.5f;
    private float timer;
    public GameObject coinPrefab;
    [SerializeField] public Vector2 force;

    public UnityEvent killed;

    // Start is called before the first frame update
    void Start()
    {
        timer = hitDelay;
        health = enemySO.health;
        damage = enemySO.damage;
        gameObject.GetComponent<enemyMove>().speed = enemySO.speed;
        onDeathPrefab = enemySO.onDeathPrefab;
        coinPrefab = enemySO.coinPrefab;
        killed.AddListener(onDeath);
    }

    void onDeath()
    {
        Destroy(gameObject);
        Instantiate(onDeathPrefab, transform.position, Quaternion.identity);
    }
    private IEnumerator Flash()
    {
        // Debug.Log("waiting");
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;

    }

    private IEnumerator damageTower(Collider2D collision)
    {
        while (health >= 0 && collision != null)
        {
            collision.gameObject.GetComponent<towerManager>().health -= damage;
            yield return new WaitForSeconds(1f);
        }
        gameObject.GetComponent<enemyMove>().attacking = false;
        rb.WakeUp();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("tower"))
        {
            rb.Sleep();
            gameObject.GetComponent<enemyMove>().attacking = true;
            StartCoroutine(damageTower(collision));
        }
        if (collision.gameObject.tag == "Throwable" && gameObject.tag != "boss")
        {
            collision.gameObject.GetComponent<DragNShoot2>().collisions -= 1;

            if (collision.gameObject.GetComponent<DragNShoot2>().rb.velocity.x > 0)
            {
                if (gameObject.tag == "boss")
                {
                    gameSO.bossDie();
                }
                else{
                    gameSO.enemyDie();
                }
                killed.Invoke();
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
        if (collision.gameObject.CompareTag("projectile") || collision.gameObject.CompareTag("explosive"))
        {
            StartCoroutine(Flash());
            health -= collision.gameObject.GetComponent<projectileManager>().damage;
            collision.gameObject.GetComponent<projectileManager>().pierce -= 1;
            print(collision.gameObject.GetComponent<projectileManager>().damage);

            if (health <= 0)
            {
                if (gameObject.tag == "boss")
                {
                    gameSO.bossDie();
                }
                else{
                    gameSO.enemyDie();
                }
                killed.Invoke();
                Instantiate(coinPrefab, transform.position, Quaternion.identity);
            }

        }
        
    }
    void Update()
    {
    }
}
