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

    //Dynamic song information
    public float songPosition;
    public float songPosInBeats;
    public float dspSongTime;
    public bool musicStarted = false;

    void Start (){
        onStart();
    }

    public void onStart(){
        //Calculate the number of seconds per beat
        secPerBeat = 60f / beatTempo;
        songPosition = startingPosition;
        songPosInBeats = songPosition / secPerBeat;
        dspSongTime = (float)AudioSettings.dspTime - startingPosition;
        musicSource.Play();
        musicStarted = true;
    }

    void Update () {
        //Only do things if the music has started
        if (!musicStarted) return;
        //calculate the position of the song in seconds from dsp space
        songPosition = (float)(AudioSettings.dspTime - dspSongTime);
        //calculate the position in beats
        songPosInBeats = songPosition / secPerBeat;
    }
    
}
