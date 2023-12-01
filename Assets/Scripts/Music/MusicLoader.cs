using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLoader : MonoBehaviour
{
    //Static song information
    public float beatTempo;
    public int musicStartOffsetInBeats = 0;
    public float secPerBeat;
    public float startingPosition;
    public AudioSource musicSource;
    public VariableTimer timer;
    public int songLenInBeats;

    //Dynamic song information
    public float songPosition;
    public float songPosInBeats;
    public float dspSongTime;
    public bool musicStarted = false;

    private void Awake() {
        Setup();
    }

    public void Setup(){
        //Calculate the number of seconds per beat
        secPerBeat = 60f / beatTempo;
        songPosition = startingPosition;
        songPosInBeats = songPosition / secPerBeat;
        
        dspSongTime = (float)AudioSettings.dspTime - startingPosition;
        songLenInBeats = (int)(musicSource.clip.length/secPerBeat);
        timer = gameObject.AddComponent(typeof(VariableTimer)) as VariableTimer;
        timer.StartTimer(musicStartOffsetInBeats*secPerBeat);
    }

    void Update () {
        if(musicStarted){
            //calculate the position of the song in seconds from dsp space
            if(musicSource.isPlaying == true){
                songPosition = (float)(AudioSettings.dspTime - dspSongTime);
                songPosInBeats = songPosition / secPerBeat;
            }
            
        }
        else{
            if(timer.finished){
                musicSource.Play();
                musicStarted = true;
            } 
        } 
    }
    
}
