using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public void PlayGame ()
    {
        SceneManager.LoadScene("pilot");
    }

    public void QuitGame ()
    {
        Debug.Log("Quit the game");
        Application.Quit();
    }

}
