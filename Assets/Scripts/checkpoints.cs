using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoints : MonoBehaviour
{
    private gamemaster gm;

    void Start(){
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<gamemaster>();
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            gm.lastCheckPointPos = transform.position;
        }
    }
}
