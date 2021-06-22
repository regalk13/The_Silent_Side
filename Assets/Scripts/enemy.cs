using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy : MonoBehaviour
{
    public GameObject player;
    private Animator Animator;
    public float speed;
    public bool Moveright;

    private float LastHit;
    private AudioSource[] mysounds;

    private AudioSource footstep;
    private AudioSource bark;
    private AudioSource cry;
    
    void Start()
    {
        Animator = GetComponent<Animator>();
        mysounds = GetComponents<AudioSource>();

        footstep = mysounds[0];
        bark = mysounds[1];
        cry = mysounds[2];
    }

    private void Update()
    { 
       float distance = Mathf.Abs(player.transform.position.x - transform.position.x);

        if(Moveright){
            transform.Translate(2 * Time.deltaTime * speed,0,0);
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            Animator.SetBool("running", true);
        }
        else{
            transform.Translate(-2 * Time.deltaTime * speed,0,0);
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            Animator.SetBool("running", true);
        }

       Animator.SetBool("hiting", false);

       if (distance < 1.0f && Time.time > LastHit + 0.25f)
       {
           Hit();
           LastHit = Time.time;
           Animator.SetBool("running", false);
       }
    }
    private void Hit()
    {
        Animator.SetBool("hiting", true);
        Animator.SetBool("running", false);
    }

    void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.CompareTag("turn"))
            {
                if(Moveright){
                    Moveright = false;
                }
                else{
                    Moveright = true;
                }
            }

            if(other.gameObject.CompareTag("ball"))
            {
                Animator.SetBool("dead", true);
            }
        }
    
    private void dead()
    {
        Destroy(gameObject);
    }

    private void Footstep()
    {
        footstep.Play();
    }

    private void barked()
    {
        bark.Play();
    }

    private void cri()
    {
        cry.Play();
    }

}
