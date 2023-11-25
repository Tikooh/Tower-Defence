using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class DragNshoot : MonoBehaviour
{
    public float power = 10f;
    public Rigidbody2D rb;
    public Vector2 minPower;
    public Vector2 maxPower;
    public Animator animator;
    Vector2 stationary;

    public TrajectoryLine tl;
    Camera cam; //change mouse position from screen position to world position
    Vector2 force;
    Vector3 startPoint;
    Vector3 endPoint;
    Vector2 yForce;
    // Start is called before the first frame update
    private void Start()
    {
        cam = Camera.main;
        tl = GetComponent<TrajectoryLine>();
        stationary = new Vector2(0,0);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPoint = cam.ScreenToWorldPoint(Input.mousePosition); //begins as pixels due to screensize
            // startpoint has -10 on z axis
            startPoint.z = 15;
            
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            currentPoint.z = 15;
            tl.RenderLine(startPoint, currentPoint);
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (gameObject.tag == "Throwable")
            {
                
            }
            endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            
            endPoint.z = 15;
            force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
            
            // Debug.Log(force);           
            rb.AddForce(force * power, ForceMode2D.Impulse);
            animator.SetFloat("speed", 1);
            //  Debug.Log(force);
             //clamps points between each other
        }
        if (rb.velocity.x <= -0.01)
        {
            gameObject.tag = "towerPlaceable";
            rb.velocity = stationary;
        }
        yForce = new Vector2(rb.velocity.x, 0); 

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "backboard")
        {
            rb.velocity = stationary;
            gameObject.tag = "towerPlaceable";
        }
    }
    
}
