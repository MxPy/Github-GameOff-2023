using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetContorller : MonoBehaviour
{
    public TargetTrigger top, middle, bottom;
    public int jumpCase;
    public PlayerContorller playerContorller;
    private VariableTimer keyPressTimer, noteWindowTimer;


    private void Start() {
        keyPressTimer = gameObject.AddComponent(typeof(VariableTimer)) as VariableTimer;
        noteWindowTimer = gameObject.AddComponent(typeof(VariableTimer)) as VariableTimer;
    }
    void KeyController(){
        

    }

    private void Update() {
        KeyController();
    }
}
