using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class girlmove : MonoBehaviour
{
    public GameObject ballpref;
    public float Speed;
    public float JumpForce;
    public GameObject text;
    public bool canMove;

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

        canMove = true;
    }

    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        if (canMove && Horizontal < 0.0f)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            Animator.SetBool("running", Horizontal != 0.0f);
        }
        else if (canMove && Horizontal > 0.0f) 
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);   
            Animator.SetBool("running", Horizontal != 0.0f);  
        }
        
    
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        {
            Grounded = true;
        }

        else Grounded = false;

        if (canMove && Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
            Animator.SetBool("jumper", true);
        }

        if (canMove && Input.GetKeyDown(KeyCode.C) && Time.time > lastshoot + 0.25f)
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
        if (canMove) {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
        }
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

        if(canMove && transform.localScale.x == 1.0f) 
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
        if (canMove) {
            Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y);
            Animator.SetBool("running", Horizontal != 0.0f);
        }
    }

    private void Footstep(){
        footstep.Play();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("ischat"))
        {
            dialog.corot();
            canMove = false;
            Animator.SetBool("running", false);  
        }
        else{
            canMove = true;
        }
    }
}
