using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class DragNShoot2 : MonoBehaviour
{
    public float power = 10f;
    public Rigidbody2D rb;
    public Vector2 minPower;
    public Vector2 maxPower;
    public Animator animator;
    Vector2 stationary;

    Camera cam; //change mouse position from screen position to world position
    Vector2 force;
    Vector3 startPoint;
    Vector3 endPoint;
    Vector2 yForce;
    float duration = 0.6f;
    // Start is called before the first frame update
    private void Start()
    {
        cam = Camera.main;
        stationary = new Vector2(0,0);
    }
    private IEnumerator UpdatePosition(float duration)
    {
        while (true)
        {
            startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            yield return new WaitForSeconds(duration);
            // Debug.Log(string.Format("Current Position {0}", startPoint));
        }

    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse pressed");
            StartCoroutine(UpdatePosition(duration));
            
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (gameObject.tag == "Throwable")
            {
                endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
                // Debug.Log(string.Format("End Position {0}", endPoint));
                
                endPoint.z = 15;
                force = new Vector2(Mathf.Clamp((endPoint.x - startPoint.x)/3 , minPower.x, maxPower.x), Mathf.Clamp((endPoint.y - startPoint.y)/3, minPower.y, maxPower.y));
                
                // Debug.Log(string.Format("force {0}", force));           
                rb.AddForce(force * power, ForceMode2D.Impulse);
                animator.SetFloat("speed", 1);
                //  Debug.Log(force);
                //clamps points between each other
            }

        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "backboard")
        {
            rb.velocity = stationary;
            gameObject.tag = "towerPlaceable";
            Destroy(gameObject);
        }

        if (rb.velocity.x <= -0.01 && collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Collision with enemy");
            gameObject.tag = "towerPlaceable";
            rb.velocity = stationary;
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            
        }
        yForce = new Vector2(rb.velocity.x, 0); 
    }
    
}

