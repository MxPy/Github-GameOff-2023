using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
    public GameObject pause;
    private bool isPaused;
    private void Start()
    {
        isPaused = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused){
                ResumeGame();
            }
            else{
                PauseGame();
            }
        }
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;

        if(pause != null){
            pause.SetActive(true);
        }
    }
    
    public void ResumeGame()
    {
        Time.timeScale = 1;
        isPaused = false;

        if (pause != null){
            pause.SetActive(false);
        }
    }
}


