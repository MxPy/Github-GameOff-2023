using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Specialized;

public class TargetContorller : MonoBehaviour
{
    public TargetTrigger top, middle, bottom;
    public bool qPressed = false, wPressed = false, ePressed = false;
    BitVector32 bitvector;
    public int jumpCase;
    public PlayerContorller playerContorller;
    private VariableTimer keyPressTimer, noteWindowTimer;


    private void Start() {
        keyPressTimer = gameObject.AddComponent(typeof(VariableTimer)) as VariableTimer;
        noteWindowTimer = gameObject.AddComponent(typeof(VariableTimer)) as VariableTimer;
        bitvector = new BitVector32();
    }
    void KeyController(){
        
        if (Input.GetKeyDown(KeyCode.Q) && keyPressTimer.finished != true){
            Debug.Log("Q key pressed");
            qPressed = true;
            if(keyPressTimer.started == false){
                keyPressTimer.StartTimer(0.5f);
            }
        } 
        if (Input.GetKeyDown(KeyCode.W) && keyPressTimer.finished != true){
            Debug.Log("W key pressed");
            wPressed = true;
            if(keyPressTimer.started == false){
                keyPressTimer.StartTimer(0.5f);
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && keyPressTimer.finished != true){
            Debug.Log("E key pressed");
            ePressed = true;
            if(keyPressTimer.started == false){
                keyPressTimer.StartTimer(0.5f);
            }
        }

    }

    private void Update() {
        KeyController();
    }
}
