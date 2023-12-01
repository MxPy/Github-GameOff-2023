using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public VariableTimer timer;
    public bool gameStarted = false;
    public MusicLoader musicLoader;
    public GameObject startPlatform;

    private void Start() {
        timer = gameObject.AddComponent(typeof(VariableTimer)) as VariableTimer;
        StartGame();
    }

    public void StartGame(){
        timer.StartTimer(musicLoader.musicStartOffsetInBeats*musicLoader.secPerBeat+1f);
    }

    private void FixedUpdate() {
        if(timer.finished){
            startPlatform.SetActive(false);
            timer.ResetTimer();
        }
    }
}
