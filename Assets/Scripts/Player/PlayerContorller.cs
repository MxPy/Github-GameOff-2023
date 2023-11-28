using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerContorller : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    private CircleCollider2D circleCollider2D;
    [SerializeField] private LayerMask groundLayer;
    [Range(0, 10f)] [SerializeField] private float speed = 0f;
    [Range(0, 10f)] [SerializeField] float jumpvel = 0f;
 
    float horizontal = 0f;
    float lastJumpY = 0;
    private bool isFacingRight = true;
    public bool jump = false;
 
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        circleCollider2D = GetComponent<CircleCollider2D>();
    }
 
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal") * speed;
 
        // play correct animations while moving...
        //if(isOnGround() && horizontal.Equals(0))
            //GetComponent<Animator>().Play("Player_Idle_Right");
         
        if (isOnGround() && Input.GetKeyDown(KeyCode.Space)) jump = true;

        Debug.Log(isOnGround());
 
        if (!isOnGround())
        {
            if (lastJumpY < transform.position.y)
            {
                lastJumpY = transform.position.y;
                //GetComponent<Animator>().Play("Player_Jump_Up_Right");
            }
            else if(lastJumpY > transform.position.y)
            {
                //GetComponent<Animator>().Play("Player_Jump_Down_Right");
            }
        }
    }
 
    void FixedUpdate()
    {
        float moveFactor = horizontal * Time.fixedDeltaTime;
 
        // Movement...
        rigidBody2D.velocity = new Vector2(moveFactor * 10f, rigidBody2D.velocity.y);
 
        // Flip the sprite according to movement direction...
        if (moveFactor > 0 && !isFacingRight)    flipSprite();
        else if(moveFactor < 0 && isFacingRight) flipSprite();
 
        // Jumping...
        if (jump)
        {
            
            rigidBody2D.velocity = Vector2.up * jumpvel;
            jump = false;
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
}
