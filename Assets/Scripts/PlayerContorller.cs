using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContorller : MonoBehaviour
{
    public float speed;
    private float jump;
    public bool isGrounded;
    private float moveVelocity;
    public Rigidbody2D rb;
    public int gravity = 3;
    
    void Start()
    {
        jump = 5*gravity;
    }

    
    void Update()
    {
        if(isGrounded == true){
            //jump on space for debug
            if (Input.GetKey(KeyCode.Space)){
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);
            }
        // moving UpSide
        if (rb.velocity.y > 0) {
                rb.gravityScale = gravity;
            }
        // moving on ground
        else {
                rb.gravityScale = gravity*2;
            }
        }
        moveVelocity = 0;
        if (Input.GetKey(KeyCode.LeftArrow)){
            moveVelocity = -speed;
        }
        if (Input.GetKey(KeyCode.RightArrow)){
            moveVelocity = speed;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
    }
    void OnCollisionEnter2D(Collision2D col){
        isGrounded = true;
    }
    void OnCollisionExit2D(Collision2D col){
        isGrounded = false;
    }
}
