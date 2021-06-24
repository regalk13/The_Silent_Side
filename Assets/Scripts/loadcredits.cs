using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadcredits : MonoBehaviour
{
    public int Respawn;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine (showTextFuntion());
    }

    IEnumerator showTextFuntion(){
        yield return new WaitForSeconds (40f);
        SceneManager.LoadScene(Respawn);
        
    }
}