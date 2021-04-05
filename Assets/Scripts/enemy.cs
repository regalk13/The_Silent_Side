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
    
    void Start()
    {
        Animator = GetComponent<Animator>();
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
        Debug.Log("Hit");
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
        }
}
