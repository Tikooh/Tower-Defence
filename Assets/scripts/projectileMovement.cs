using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class projectileMovement : MonoBehaviour
{
    public int speed;
    public Rigidbody2D rb;
    Vector2 force;
    // Start is called before the first frame update
    void Start()
    {
        force = new Vector2(speed, 0f);
        rb.AddForce(force, ForceMode2D.Impulse);
    }

}
