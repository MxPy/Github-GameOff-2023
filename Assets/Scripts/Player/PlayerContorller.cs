using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerContorller : MonoBehaviour

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

        Debug.Log(isOnGround());
 
        if (!isOnGround())
        {
            if (lastJumpY < transform.position.y)
            {
                lastJumpY = transform.position.y;
                //GetComponent<Animator>().Play("Player_Jump_Up_Right");
            }
            }
            // moving on ground
            else {
                    rb.gravityScale = gravity*2;
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
