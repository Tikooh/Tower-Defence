using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using Microsoft.Win32.SafeHandles;
using UnityEngine;

public class projectileMovement : MonoBehaviour
{
    public int speed;
    public Rigidbody2D rb;
    Vector2 force;
    // Start is called before the first frame update
    void Update()
    {
        if (force == Vector2.zero)
        {
            force = new Vector2(speed, 0f);
            rb.AddForce(force, ForceMode2D.Impulse);
        }

    }

}
