using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class TargetContorller : MonoBehaviour
{
    public TargetTrigger top, middle, bottom;
    public bool[] keyBools, noteBools;
    public bool jumped = false;
    public int keyPressedValue = -1;
    public int jumpCase = -1, noteNow = -1;
    public float noteWindowTime = 0.5f;
    public PlayerContorller playerContorller;
    private VariableTimer keyPressTimer, noteKeyWindowTimer, noteEnterWindowTimer;


    private void Start() {
        keyPressTimer = gameObject.AddComponent(typeof(VariableTimer)) as VariableTimer;
        noteKeyWindowTimer = gameObject.AddComponent(typeof(VariableTimer)) as VariableTimer;
        noteEnterWindowTimer = gameObject.AddComponent(typeof(VariableTimer)) as VariableTimer;
        
        keyBools = new bool[3] {false, false, false};
        noteBools = new bool[3] {false, false, false};
    }
    void KeyController(){
        if(noteKeyWindowTimer.started == false){
            if (Input.GetKeyDown(KeyCode.Q) && keyPressTimer.finished != true){
                //Debug.Log("Q key pressed");
                keyBools[0] = true;
                if(keyPressTimer.started == false){
                    keyPressTimer.StartTimer(0.025f);
                }
            } 
            if (Input.GetKeyDown(KeyCode.W) && keyPressTimer.finished != true){
                //Debug.Log("W key pressed");
                keyBools[1] = true;
                if(keyPressTimer.started == false){
                    keyPressTimer.StartTimer(0.025f);
                }
            }
            if (Input.GetKeyDown(KeyCode.E) && keyPressTimer.finished != true){
                //Debug.Log("E key pressed");
                keyBools[2] = true;
                if(keyPressTimer.started == false){
                    keyPressTimer.StartTimer(0.025f);
                }
            }
            if(keyPressTimer.finished == true){
                //magic
                keyPressedValue = Convert.ToInt32(string.Join("",keyBools.Select(b => b ? 1 : 0)), 2);
                //Debug.Log("update");
                noteKeyWindowTimer.StartTimer(noteWindowTime);
            }
        }
    }
    void NotesEnterConroller(){
        if(top.noteEnter || middle.noteEnter || bottom.noteEnter){
            if(noteEnterWindowTimer.started == false){
                noteBools[0] = top.noteEnter;
                noteBools[1] = middle.noteEnter;
                noteBools[2] = bottom.noteEnter;
                noteNow =  Convert.ToInt32(string.Join("",noteBools.Select(b => b ? 1 : 0)), 2);
                noteEnterWindowTimer.StartTimer(noteWindowTime);
                //Debug.Log("noteEnterWindowTimer started");
            }
        }
    }
    void TimersLogicContorller(){
        if(playerContorller.isOnGround() && noteEnterWindowTimer.started == true && noteEnterWindowTimer.finished == false && noteKeyWindowTimer.started == true && noteKeyWindowTimer.finished == false && jumped == false){
            //Debug.Log(noteNow);
            //Debug.Log("key "+keyPressedValue);
            if(noteNow == keyPressedValue){
                playerContorller.jump = true;
                jumped = true;
            }
        }

        if(noteKeyWindowTimer.finished == true){
            keyPressTimer.ResetTimer();
            noteKeyWindowTimer.ResetTimer();
            jumped = false;
            keyBools[0] = false;
            keyBools[1] = false;
            keyBools[2] = false;
        }
        if(noteEnterWindowTimer.finished == true){
            noteEnterWindowTimer.ResetTimer();
            jumped = false;
            noteBools[0] = false;
            noteBools[1] = false;
            noteBools[2] = false;
        }
    }
    private void Update() {
        KeyController();
        NotesEnterConroller();
        TimersLogicContorller();
    }
}
