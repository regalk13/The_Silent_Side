using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationActivator : MonoBehaviour
{
    public GameObject notify;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            notify.SetActive(true);
        }
    }
}
