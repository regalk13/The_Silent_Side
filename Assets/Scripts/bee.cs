using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bee : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.CompareTag("ball"))
            {
                Destroy(gameObject);
            }
        }
}
