using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transitions : MonoBehaviour
{
    private Animator transition;
    void Start()
    {
    
        transition = GetComponent<Animator>();
        
    }
    public void LoadScne(string scene)
    {
        StartCoroutine(Transiciona(scene));
    }
    IEnumerator Transiciona(string scene)
    {
        transition.SetTrigger("final");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(scene);
    }

}
