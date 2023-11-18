using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLoader : MonoBehaviour
{
    //Static song information
    public float beatTempo;
    public float secPerBeat;
    private float offsetToFirstBeat;
    public AudioSource musicSource;

    //Dynamic song information
    public float songPosition;
    public float songPosInBeats;
    public float dspSongTime;
    public bool musicStarted = false;
}
