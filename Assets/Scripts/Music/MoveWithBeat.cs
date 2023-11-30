using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithBeat : MonoBehaviour
{
    public MusicLoader musicLoader;
    public GameObject target;
    public TargetContorller targetContorller;
    private float time;
    public int targetNum = 0;
    private Vector3 direction;
    private float distance;

    private void Start() {
        musicLoader = GameObject.FindGameObjectsWithTag("MusicLoader")[0].GetComponent("MusicLoader") as MusicLoader;
        targetContorller = GameObject.FindGameObjectsWithTag("TargetContorller")[0].GetComponent("TargetContorller") as TargetContorller;
        target = GameObject.FindGameObjectsWithTag("Target")[targetNum];
        direction = target.transform.position - transform.position;
        distance = direction.magnitude/120;
        time = musicLoader.secPerBeat;
    }
    void Update()
    {
        gameObject.transform.Translate(direction * (Time.deltaTime*(distance/time)));
        
    }
    //TODO rename

    public void DestroyTopNote(){
        targetContorller.DestroyTopNote(gameObject);
    }
    public void DestroyMiddleNote(){
        targetContorller.DestroyMiddleNote(gameObject); 
    }
    public void DestroyBottomNote(){
        targetContorller.DestroyBottomNote(gameObject);   
    }
}
