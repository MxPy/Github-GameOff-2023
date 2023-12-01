using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteHP : MonoBehaviour
{
    public GameObject HP1, HP2, HP3, loseScreen;
    public PlayerContorller playerContorller;
    public GameStart start;

    //Refractor this
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.name == "Player"){
                if(playerContorller.HP == 3){
                    HP3.SetActive(false);
                    start.StartGame();
                    playerContorller.RestetSlider();
                    playerContorller.HP--;
                }else if(playerContorller.HP == 2){
                    HP2.SetActive(false);
                    start.StartGame();
                    playerContorller.RestetSlider();
                    playerContorller.HP--;
                }else if(playerContorller.HP == 1){
                    HP1.SetActive(false);
                    start.StartGame();
                    playerContorller.RestetSlider();
                    playerContorller.HP--;
                }else{
                    loseScreen.SetActive(true);
                }
        }
    }
}
