using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


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

    public Image image;
    public GameObject Images;
    public Sprite heart1;
    public Sprite heart2;
    public Sprite heart3;
    public Sprite heart4;
    public Sprite heart5;
    public Sprite heart6;
    public Sprite heart7;
    public Sprite heart0;

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

        if(hited == 1)
        {
            image.sprite = heart1;
        }
        if(hited == 2)
        {
            image.sprite = heart2;
        }
        if(hited == 3)
        {
            image.sprite = heart3;
        }
        if(hited == 4)
        {
            image.sprite = heart4;
        }
        if(hited == 5)
        {
            image.sprite = heart5;
        }
        if(hited == 6)
        {
            image.sprite = heart6;
        }
        if(hited == 7)
        {
            image.sprite = heart7;
        }

        if(hited == 8)
        {
            image.sprite = heart0;
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
        deadscene.SetActive(true); 
        Images.SetActive(false);   
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(6);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
