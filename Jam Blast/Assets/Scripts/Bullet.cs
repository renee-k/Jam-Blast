using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 50f;
    public Rigidbody2D rb;

    void Start ()
    {
        rb.velocity = transform.right * -speed;
    }

    // Update is called once per frame
    void Update()
    {
        Invoke ("Destroy", 0.35f);
    }

    void Destroy()
    {
        DestroyImmediate (gameObject, true);
    }
}
