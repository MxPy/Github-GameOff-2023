using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetContorller : MonoBehaviour
{
    public TargetTrigger top, middle, bottom;
    public bool topJump = false, middleJump = false, bottomJump = false;
    public bool canJump = false;
    public PlayerContorller playerContorller;

    private void Update() {

    }
}
