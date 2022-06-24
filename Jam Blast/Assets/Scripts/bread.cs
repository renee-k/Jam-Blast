using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bread : MonoBehaviour
{
    public float speed = 50f;
    public float upForce = 50f;
    public Rigidbody2D rb;

    void Start ()
    {
        rb.AddForce(new Vector2(0, upForce));
        // rb.velocity = transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {
        Invoke ("Destroy", 1.9f);
    }

    void Destroy()
    {
        DestroyImmediate (gameObject, true);
    }

    public void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            GameControl.instance.BirdDied ();
    }
}
