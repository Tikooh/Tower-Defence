using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemyMove : MonoBehaviour
{
    public Rigidbody2D enemyRb;
    [SerializeField] public int speed;
    // Start is called before the first frame update

    // Update is called once per frame
    void FixedUpdate()
    {
        enemyRb.velocity = Vector2.left * speed;
    }
}
