using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithBeat : MonoBehaviour
{
    public MusicLoader musicLoader;
    public GameObject target;
    private float time;
    public int targetNum = 0;
    private Vector3 direction;
    private float distance;

    private void Start() {
        musicLoader = GameObject.FindGameObjectsWithTag("MusicLoader")[0].GetComponent("MusicLoader") as MusicLoader;
        target = GameObject.FindGameObjectsWithTag("Target")[targetNum];
        direction = target.transform.position - transform.position;
        distance = direction.magnitude/120;
        time = musicLoader.secPerBeat;
    }
    void Update()
    {
        if(musicLoader.musicStarted){
            gameObject.transform.Translate(direction * (Time.deltaTime*(distance/time)));
        }
    }
}
