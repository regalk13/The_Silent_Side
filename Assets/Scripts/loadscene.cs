using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadscene : MonoBehaviour
{
    public int Respawn;
    
    public void scene()
    {
        SceneManager.LoadScene(Respawn);
    }
}
