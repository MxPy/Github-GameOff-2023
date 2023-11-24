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

    //for animation
    public bool facingRight = true;
    public Animator animator;

    public TargetContorller targetContorller;
 
    void FixedUpdate()
        {
            float h = Input.GetAxis("Horizontal");
            if(h > 0 && !facingRight)
                Flip();
            else if(h < 0 && facingRight)
                Flip();
        }
    void Flip ()
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    
    void Start()
    {
        jump = 5*gravity;
        timer = gameObject.AddComponent(typeof(VariableTimer)) as VariableTimer;
    }
    void Update()
    {
       JumpingAnimation();
       movment();
    }

    void JumpingAnimation(){
        animator.SetBool("isGrounded", isGrounded);
        if (rb.velocity.y > 0) {animator.SetBool("isFalling", false);}
        else{animator.SetBool("isFalling", true);}
    }

    //player movment
    void movment(){
         if(isGrounded == true){
            //jump on w for debug
            if (targetContorller.canJump){
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);
            }
            // attack 
            //jump on space for debug
            if (Input.GetKey(KeyCode.Space)){
                animator.SetBool("IsAttack", true);
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);
                //animator.SetBool("IsAttack", false);
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

    // ending of attack animation trigged form animation event 
    public void BackFromAttack(){
        animator.SetBool("IsAttack", false);
    }
    
}
