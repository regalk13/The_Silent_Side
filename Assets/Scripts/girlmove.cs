using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class girlmove : MonoBehaviour
{
    public float Speed;
    public float JumpForce;

    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Grounded;
    private AudioSource footstep;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        footstep = GetComponent<AudioSource>();
    }

    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Horizontal < 0.0f)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
        else if (Horizontal > 0.0f) 
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);     
        }
        Animator.SetBool("running", Horizontal != 0.0f);
    
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        {
            Grounded = true;
        }

        else Grounded = false;

        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
            Animator.SetBool("jumper", true);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Animator.SetBool("hited", true);
        }
        else
        {
            Hited();
        }
    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    public void jumped()
    {
        Animator.SetBool("jumper", false);  
    }

    public void Hited()
    {
        Animator.SetBool("hited", false);  
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y);
    }

    private void Footstep(){
        footstep.Play();
    }
}
