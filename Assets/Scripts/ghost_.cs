using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ghost_ : MonoBehaviour
{
   public GameObject player;
    private Animator Animator;
    public float speed;
    public bool Moveright;
    public GameObject deadscene;

    private float LastHit;
    private AudioSource[] mysounds;

    private AudioSource hit;
    private AudioSource deads;
    private int hited;
    public GameObject sounder;


    void Start()
    {
        Animator = GetComponent<Animator>();
        mysounds = GetComponents<AudioSource>();

        hit = mysounds[0];
        deads = mysounds[1];
    }

    private void Update()
    { 
       float distance = Mathf.Abs(player.transform.position.x - transform.position.x);

        if(Moveright){
            transform.Translate(2 * Time.deltaTime * speed,0,0);
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
        else{
            transform.Translate(-2 * Time.deltaTime * speed,0,0);
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }

       Animator.SetBool("hiting", false);

       if (distance < 5.0f && Time.time > LastHit + 0.25f)
       {
           Hit();
           LastHit = Time.time;
       }

        if(hited >= 10)
        {
            StartCoroutine(dead());
        }

    }
    private void Hit()
    {
        Debug.Log("Hit");
        Animator.SetBool("hiting", true);
        // Animator.SetBool("running", false);
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
                hit.Play();
                hited++;
                Debug.Log(hited);
            }
        }
    
    IEnumerator dead()
    {
        sounder.SetActive(false);
        yield return new WaitForSeconds(1f);
        deadscene.SetActive(true); 
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(6);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
