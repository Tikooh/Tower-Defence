using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemyMove : MonoBehaviour
{
    public Rigidbody2D enemyRb;
    [System.NonSerialized] public bool attacking;
    [System.NonSerialized] public float speed;
    // Start is called before the first frame update

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!attacking)
        {
            enemyRb.velocity = Vector2.left * speed;
        }
        
    }
}
