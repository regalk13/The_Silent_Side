using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playerpos : MonoBehaviour
{
    private gamemaster gm;
    public int Respawn;
    public Vector2 newcheckpoint;

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Enemy")){
            Inscene();
        }
        if(other.CompareTag("Load")){
            ChangeScene();
        }
    }

    void ChangeScene()
    {
        Debug.Log("Changing to Scene2");
        SceneManager.LoadScene(Respawn);

        Scene scene = SceneManager.GetSceneByBuildIndex(Respawn);
        SceneManager.SetActiveScene(scene);

        transform.position = newcheckpoint;
    }

    void Inscene(){
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<gamemaster>();
        transform.position = gm.lastCheckPointPos;
    }
}
