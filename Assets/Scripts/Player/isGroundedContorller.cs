using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isGroundedContorller : MonoBehaviour
{
    public PlayerContorller player;
    void OnCollisionEnter2D(Collision2D col){
        //player.isGrounded = true;
    }
    void OnCollisionExit2D(Collision2D col){
        //player.isGrounded = false;
    }
}
