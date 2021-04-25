using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemaster : MonoBehaviour
{
    private static gamemaster instance;
    public Vector2 lastCheckPointPos;

    void Awake(){

        if(instance == null){
            instance = this;
            DontDestroyOnLoad(instance);
        }else{
            Destroy(gameObject);
        }
    }
}
