using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playerpos : MonoBehaviour
{
    private gamemaster gm;
    public int Respawn;
    public Vector2 newcheckpoint;
    public Animator m_Animator;
    public Animator n_Animator;
    public GameObject load;
    public GameObject load2;

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Enemy")){
            StartCoroutine(Inscene());
        }
        if(other.CompareTag("Load")){
            StartCoroutine(ChangeScene());
        }
    }

    IEnumerator ChangeScene()
    {
        load2.SetActive(true);
        n_Animator = load2.GetComponent<Animator>();

        yield return new WaitForSeconds(1f);


        Debug.Log("Changing to Scene2");
        SceneManager.LoadScene(Respawn);

        Scene scene = SceneManager.GetSceneByBuildIndex(Respawn);
        SceneManager.SetActiveScene(scene);

        transform.position = newcheckpoint;   
    }

    IEnumerator Inscene(){
        load.SetActive(true);
        m_Animator = load.GetComponent<Animator>();
        
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<gamemaster>();
        transform.position = gm.lastCheckPointPos;
        yield return new WaitForSeconds(2f);
        load.SetActive(false);
    }
}
