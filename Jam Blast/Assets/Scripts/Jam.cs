using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jam : MonoBehaviour
{
        public float upForce = 200f;                    //Upward force of the "jump".
        public float downForce = -100f;
        private bool isDead = false;            //Has the player collided with an obstacle?

        private Animator anim;                    //Reference to the Animator component.
        private Rigidbody2D rb2d;                //Holds a reference to the Rigidbody2D component of the blob.
        private bool doubleJump = false;
        private AudioSource jump;
        private bool onGround = false;
        public Collider2D main;
        public CapsuleCollider2D crouch;

    // Start is called before the first frame update
    void Start()
    {
        //Get reference to the Animator component attached to this GameObject.
        anim = GetComponent<Animator> ();
        //Get and store a reference to the Rigidbody2D attached to this GameObject.
        rb2d = GetComponent<Rigidbody2D>();
        main = GetComponent<Collider2D>();
        crouch = GetComponent<CapsuleCollider2D>();
        jump = GetComponent<AudioSource>();
    }

    void Update()
    {       
        //Don't allow control if the blob has died.
        if (isDead == false) 
        {
          if (rb2d.velocity.y == 0)
            onGround = true;
          else
            onGround = false;

          if (onGround)
            doubleJump = true;
          
          //Look for input to trigger a "jump".
          if (Input.GetKeyDown("space") && onGround)
          {
            jump.Play();
            anim.SetTrigger("Jump");
            rb2d.AddForce(new Vector2(0, upForce));
          }
          else if (Input.GetKeyDown("space") && doubleJump) 
          {
            anim.SetTrigger("Jump");
            rb2d.AddForce(new Vector2(0, upForce));
            doubleJump = false;
          }

          // Ducking
          if (Input.GetButtonDown("crouch"))
          {
            anim.SetTrigger("Duck");
            main.enabled = !main.enabled;
            crouch.enabled = true;
            rb2d.AddForce(new Vector2(0, downForce));
          }
          
          if (Input.GetButtonUp("crouch"))
          {
            anim.SetTrigger("Main");
            main.enabled = true;
            crouch.enabled = !crouch.enabled;
          }
        }
    }
    
     void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Obstacles")
        {
        // Zero out the bird's velocity
        rb2d.velocity = Vector2.zero;
        // If the bird collides with something set it to dead...
        isDead = true;
        //...tell the Animator about it...
        anim.SetTrigger ("Die");
        main.enabled = true;
        crouch.enabled = !crouch.enabled;
        //...and tell the game control about it.
        GameControl.instance.BirdDied ();
        }
    }
}
