using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTrigger : MonoBehaviour
{
    public bool noteEnter = false;
    private void OnTriggerStay2D(Collider2D other) {
        noteEnter = true;
    }
    private void OnTriggerExit2D(Collider2D other) {
        noteEnter = false;
    }
}
