using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remover : MonoBehaviour
{
    public PlayerContorller playerContorller;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.name.Contains("Note") && playerContorller.playerScore > 0){
            //playerContorller.playerScore -= 1;
        }
        Destroy(other.gameObject);
    }
}
