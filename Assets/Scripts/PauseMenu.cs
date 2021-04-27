using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    
    public static bool GamesIsPaused = false;

    public GameObject pauseMenuUI;

    public GameObject canvas;

    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape))
    {
        if (GamesIsPaused)
        {
            Resume();
        } else
        {
            Pause();
        }
    }
}

void Start () {
        pauseMenuUI.SetActive(false);
 }

public void Resume(){
    pauseMenuUI.SetActive(false);
    Time.timeScale = 1f;
    GamesIsPaused = false;
    canvas.SetActive(true);
}

void Pause(){
    pauseMenuUI.SetActive(true);
    Time.timeScale = 0f;
    GamesIsPaused = true;
    canvas.SetActive(false);
}


public void LoadMenu(){
    SceneManager.LoadScene("Menu");
}

public void QuitGame(){
    Debug.Log("Quitting Game...");
    Application.Quit();
}
}