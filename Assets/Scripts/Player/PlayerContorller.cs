using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerContorller : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    private CircleCollider2D circleCollider2D;
    [SerializeField] private LayerMask groundLayer;
    [Range(0, 20f)] [SerializeField] private float speed = 0f;
    [Range(0, 20f)] [SerializeField] float jumpvel = 0f;
 
    float horizontal = 0f;
    float lastJumpY = 0;
    public int HP = 3;
    private bool isFacingRight = true;
    public bool jump = false;
    public GameObject startPlatform;
    public int playerScore = 0;
 
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        circleCollider2D = GetComponent<CircleCollider2D>();
    }
 
    void Update()
    {
        if (!isOnGround()) horizontal = Input.GetAxisRaw("Horizontal") * speed;
        else horizontal = 0;
 
        // play correct animations while moving...
        //if(isOnGround() && horizontal.Equals(0))
            //GetComponent<Animator>().Play("Player_Idle_Right");
         
        if (isOnGround() && Input.GetKeyDown(KeyCode.Space)) jump = true;

       // Debug.Log(isOnGround());

        if(isOnGround()) GetComponent<Animator>().SetBool("isGrounded", true);
        else{
            GetComponent<Animator>().SetBool("isGrounded", false);
            GetComponent<Animator>().SetBool("isFalling", false);
        } 
 
        if (!isOnGround())
        {
            if (lastJumpY < transform.position.y)
            {
                lastJumpY = transform.position.y;
                GetComponent<Animator>().SetBool("isFalling", false);
            }
            else if(lastJumpY > transform.position.y)
            {
                GetComponent<Animator>().SetBool("isFalling", true);
            }
        }
    }
 
    void FixedUpdate()
    {
        float moveFactor = horizontal * Time.fixedDeltaTime;
 
        rigidBody2D.velocity = new Vector2(moveFactor * 10f, rigidBody2D.velocity.y);
 
        if (moveFactor > 0 && !isFacingRight)    flipSprite();
        else if(moveFactor < 0 && isFacingRight) flipSprite();
 
        if (jump)
        {
            rigidBody2D.velocity = Vector2.up * jumpvel;
            jump = false;
            startPlatform.SetActive(false);
            playerScore++;
        }
    }
 
    private void flipSprite()
    {
        isFacingRight = !isFacingRight;
 
        Vector3 transformScale = transform.localScale;
        transformScale.x *= -1;
        transform.localScale = transformScale;
    }
 
    public bool isOnGround()
    {
        RaycastHit2D hit = Physics2D.CircleCast(circleCollider2D.bounds.center, circleCollider2D.radius, Vector2.down, 0.3f, groundLayer);
        if (hit && !lastJumpY.Equals(0)) lastJumpY = 0;
        return hit.collider != null;
    }

    public void BackFromAttack(){
        //animator.SetBool("IsAttack", false);
    }
}