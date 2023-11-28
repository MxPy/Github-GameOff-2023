using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContorller : MonoBehaviour
{   
    private float jump;
    public bool isGrounded, hitWall;
    private float moveVelocity;
    private VariableTimer timer;
    
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private int gravity = 3;

    //for animation
    public Animator animator;
    public Vector2 facing;
    
    void Start()
    {
        jump = 5*gravity;
        timer = gameObject.AddComponent(typeof(VariableTimer)) as VariableTimer;
    }
    void Update()
    {
        facing.x = Input.GetAxisRaw("Horizontal");
        facing.y = Input.GetAxisRaw("Vertical");

        if(facing != Vector2.zero){
            animator.SetFloat("Horizontal", facing.x);
        }

       JumpingAnimation();
       movement();
    }

    void JumpingAnimation(){
        animator.SetBool("isGrounded", isGrounded);
        if (rb.velocity.y > 0) {animator.SetBool("isFalling", false);}
        else{animator.SetBool("isFalling", true);}
    }

    public void Jump(){
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);
    }

    //player movement
    void movement(){
         if(isGrounded == true){
            // attack 
            //jump on space for debug
            if (Input.GetKey(KeyCode.Space)){
                animator.SetBool("IsAttack", true);
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);
                animator.SetBool("IsAttack", false);
            }
            // moving UpSide
            if(rb.velocity.y != 0){
                rb.gravityScale = gravity;
            }
            // moving on ground
            else {
                    rb.gravityScale = gravity*2;
                }
        }
        moveVelocity = 0;
        if (isGrounded == false && Input.GetKey(KeyCode.LeftArrow) && hitWall == false){
            moveVelocity = -speed;
            
        }
        if (isGrounded == false && Input.GetKey(KeyCode.RightArrow) && hitWall == false){
            moveVelocity = speed;
        }
        if(timer.finished){
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
    }

    // ending of attack animation trigged form animation event 
    public void BackFromAttack(){
        animator.SetBool("IsAttack", false);
    }
    
    private void OnTriggerStay2D(Collider2D other) {
        if(isGrounded == false){
            hitWall = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(isGrounded == false){
            hitWall = false;
        }
    }
}
