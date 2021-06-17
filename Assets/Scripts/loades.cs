using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loades : MonoBehaviour
{
    public int Respawn;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine (showTextFuntion());
    }

    IEnumerator showTextFuntion(){
        yield return new WaitForSeconds (15f);
        SceneManager.LoadScene(Respawn);
        
    }
}
