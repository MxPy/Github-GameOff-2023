using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContorller : MonoBehaviour
{
    private float jump;
    public bool isGrounded;
    private float moveVelocity;
    private VariableTimer timer;
    
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private int gravity = 3;
    
    void Start()
    {
        jump = 5*gravity;
        timer = gameObject.AddComponent(typeof(VariableTimer)) as VariableTimer;
    }
    void Update()
    {
       movment();
    }

    //player movment
    void movment(){
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
        if (isGrounded == false && Input.GetKey(KeyCode.LeftArrow)){
            moveVelocity = -speed;
        }
        if (isGrounded == false && Input.GetKey(KeyCode.RightArrow)){
            moveVelocity = speed;
        }
        if(timer.finished){
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
    }
    
}
