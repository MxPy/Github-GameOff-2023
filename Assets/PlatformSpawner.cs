using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public MusicLoader musicLoader;
    private bool spawned;
    public VariableTimer timer;
    public float spawnPointX, spawnPointY, topMarginY, bottomMarginY; 
    // Start is called before the first frame update
    void Start(){
        timer = gameObject.AddComponent(typeof(VariableTimer)) as VariableTimer;
        timer.StartTimer(musicLoader.secPerBeat);
    }

    void Spawn(){
        
        spawnPointY = Random.Range(bottomMarginY, topMarginY);
        Vector3 spawnPosition = new(spawnPointX, spawnPointY, 0);
        Instantiate (platformPrefab, spawnPosition, Quaternion.Euler(0, 0, 0));
        spawned = true;  
    }

    // Update is called once per frame
    void Update(){
        if(timer.finished && spawned == false){
            Spawn();
            timer.ResetTimer();
            timer.StartTimer(musicLoader.secPerBeat);
        }else if(timer.finished && spawned == true){
            timer.ResetTimer();
            timer.StartTimer(musicLoader.secPerBeat);
            spawned = false; 
        }
        
    }
}
