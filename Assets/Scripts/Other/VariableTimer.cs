using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    

public class VariableTimer : MonoBehaviour
{
    public float actualTimeOfEvent;
    public float timreTime;
    public bool finished = false;

    private void Awake(){
        actualTimeOfEvent = float.PositiveInfinity;
    }
    
    public void StartTimer(float delay){
        actualTimeOfEvent = Time.time + delay;
        StartCoroutine (RunTimer());
        
    }
    public void ResetTimer(){
        finished = false;
    }
    private IEnumerator RunTimer(){
        while (Time.time < actualTimeOfEvent) yield return null;
        finished = true;
        //Debug.Log("EVENT!");
        actualTimeOfEvent = float.PositiveInfinity;
        
    }
}

