using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    public float speed;

    private Rigidbody2D Rigidbody2D;
    private Vector2 Direction;
    private AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Rigidbody2D.velocity = Direction * speed;
        
    }

    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    private void effect()
    {
        audio.Play();
    }
}
