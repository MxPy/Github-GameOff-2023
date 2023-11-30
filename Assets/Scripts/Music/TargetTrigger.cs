using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTrigger : MonoBehaviour
{
    public bool noteEnter = false;
    public GameObject noteTarget = null;
    private void OnTriggerStay2D(Collider2D other) {
        noteEnter = true;
        noteTarget = other.gameObject;
    }
    private void OnTriggerExit2D(Collider2D other) {
        noteEnter = false;
        noteTarget = null;
    }
}
