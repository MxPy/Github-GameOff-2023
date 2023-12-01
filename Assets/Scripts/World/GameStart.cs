using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public VariableTimer timer;
    public bool gameStarted = false;
    public MusicLoader musicLoader;
    public GameObject startPlatform, player;

    private void Start() {
        timer = gameObject.AddComponent(typeof(VariableTimer)) as VariableTimer;
        StartGame();
    }

    public void StartGame(){
        timer.StartTimer(musicLoader.musicStartOffsetInBeats*musicLoader.secPerBeat+1f);
        player.transform.position = new (startPlatform.transform.position.x, startPlatform.transform.position.y+2);
        startPlatform.SetActive(true);
    }

    private void FixedUpdate() {
        if(timer.finished){
            startPlatform.SetActive(false);
            timer.ResetTimer();
        }
    }
}
