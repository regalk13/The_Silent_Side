using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class girlmove : MonoBehaviour
{
    public GameObject ballpref;
    public float Speed;
    public float JumpForce;
    public GameObject text;

    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Grounded;
    private AudioSource footstep;
    private float lastshoot;
    private Dialog dialog;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        footstep = GetComponent<AudioSource>();
        dialog = FindObjectOfType<Dialog>();
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

        if (Input.GetKeyDown(KeyCode.C) && Time.time > lastshoot + 0.25f)
        {
            Animator.SetBool("hited", true);
            lastshoot = Time.time;
            shoot();
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

    private void shoot()
    {
        Vector3 direction;

        if(transform.localScale.x == 1.0f) 
        {
            direction = Vector2.right;
        }
        else 
        {
            direction = Vector2.left;
        }
        GameObject ballet = Instantiate(ballpref, transform.position + direction * 0.1f, Quaternion.identity);
        ballet.GetComponent<ball>().SetDirection(direction);
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y);
    }

    private void Footstep(){
        footstep.Play();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("ischat"))
        {
            dialog.corot();
        }
        else
        {
            text.SetActive(false);
        }
    }
}
