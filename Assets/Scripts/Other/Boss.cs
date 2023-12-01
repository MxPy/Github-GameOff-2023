using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int HP = 5;

    public void StartAnimation(){
        GetComponent<Animator>().Play("damage_anim");
        Debug.Log("cjh");
    }
    public void FinishAnimation(){
        GetComponent<Animator>().Play("boss_idle");
    }
}
