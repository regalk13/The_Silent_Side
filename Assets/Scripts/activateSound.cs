using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateSound : MonoBehaviour
{
    public GameObject sound;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            sound.SetActive(true);
        }
    }
}
