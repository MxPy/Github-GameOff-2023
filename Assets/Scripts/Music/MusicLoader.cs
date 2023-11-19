using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLoader : MonoBehaviour
{
    //Static song information
    public float beatTempo;
    public float secPerBeat;
    public float startingPosition;
    public AudioSource musicSource;
    public int songLenInBeats;

    //Dynamic song information
    public float songPosition;
    public float songPosInBeats;
    public float dspSongTime;
    public bool musicStarted = false;

    private void Awake() {
        onStart();
    }

    public void onStart(){
        //Calculate the number of seconds per beat
        secPerBeat = 60f / beatTempo;
        songPosition = startingPosition;
        songPosInBeats = songPosition / secPerBeat;
        
        dspSongTime = (float)AudioSettings.dspTime - startingPosition;
        songLenInBeats = (int)(musicSource.clip.length/secPerBeat);
        musicSource.Play();
        musicStarted = true;
    }

    void Update () {
        if (!musicStarted) return;
        //calculate the position of the song in seconds from dsp space
        songPosition = (float)(AudioSettings.dspTime - dspSongTime);
        songPosInBeats = songPosition / secPerBeat;
    }
    
}
