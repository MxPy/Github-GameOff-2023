using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public int HP = 5;
    public VariableTimer timer;
    public GameObject winScreen;

    private void Start() {
        timer = gameObject.AddComponent(typeof(VariableTimer)) as VariableTimer;
    }
    public void StartAnimation(){
        GetComponent<Animator>().Play("damage_anim");
        //Debug.Log("cjh");
    }
    public void FinishAnimation(){
        GetComponent<Animator>().Play("boss_idle");
    }
    private void FixedUpdate() {
        if (HP <= 0){
            if(timer.started == false) timer.StartTimer(3f);
            winScreen.SetActive(true);

        }    
        if(timer.finished){
            SceneManager.LoadScene("HubDemo");
        }
    }
}
