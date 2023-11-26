using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class TargetContorller : MonoBehaviour
{
    public TargetTrigger top, middle, bottom;
    public bool[] keyBools;
    public int keyPressedValue = 0;
    public int jumpCase;
    public PlayerContorller playerContorller;
    private VariableTimer keyPressTimer, noteKeyWindowTimer, noteEnterWindowTimer;


    private void Start() {
        keyPressTimer = gameObject.AddComponent(typeof(VariableTimer)) as VariableTimer;
        noteKeyWindowTimer = gameObject.AddComponent(typeof(VariableTimer)) as VariableTimer;
        noteEnterWindowTimer = gameObject.AddComponent(typeof(VariableTimer)) as VariableTimer;
        
        keyBools = new bool[3] {false, false, false};
    }
    void KeyController(){
        if(noteKeyWindowTimer.started == false){
            if (Input.GetKeyDown(KeyCode.Q) && keyPressTimer.finished != true){
            Debug.Log("Q key pressed");
            keyBools[2] = true;
            if(keyPressTimer.started == false){
                keyPressTimer.StartTimer(0.5f);
            }
            } 
            if (Input.GetKeyDown(KeyCode.W) && keyPressTimer.finished != true){
                Debug.Log("W key pressed");
                keyBools[1] = true;
                if(keyPressTimer.started == false){
                    keyPressTimer.StartTimer(0.5f);
                }
            }
            if (Input.GetKeyDown(KeyCode.E) && keyPressTimer.finished != true){
                Debug.Log("E key pressed");
                keyBools[0] = true;
                if(keyPressTimer.started == false){
                    keyPressTimer.StartTimer(0.5f);
                }
            }
            if(keyPressTimer.finished == true){
                //magic
                keyPressedValue = Convert.ToInt32(string.Join("",keyBools.Select(b => b ? 1 : 0)), 2);
                    noteKeyWindowTimer.StartTimer(1f);
            }
        }
    }

    private void Update() {
        KeyController();
    }
}
