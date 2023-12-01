using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
 
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
    public bool jump = false, isAttacking = false;
    public GameObject startPlatform, bullet;
    public int playerScore = 0;
    public TMP_Text scoreText;
    public Slider slider;
 
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
         
        if (isOnGround() && Input.GetKeyDown(KeyCode.Space) && slider.value == 1){
            isAttacking = true; 
            GetComponent<Animator>().SetBool("IsAttack", true);
        } 

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
            scoreText.text = playerScore.ToString();
            if(slider.value != 1){
                slider.value += 0.2f;
                Color currentColor = slider.gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().color;
                slider.gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().color = new Color(currentColor.r - 0.2f, currentColor.g + 0.2f, 0, currentColor.a);
            }
            
        }
    }

    void Spawn () {    
        Vector3 spawnPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0);
            Instantiate (bullet, spawnPosition, Quaternion.Euler(0, 0, 0));
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
        GetComponent<Animator>().SetBool("IsAttack", false);
        Spawn();
        RestetSlider();
        isAttacking = false;
        //Debug.Log("chuj");
    }

    public void RestetSlider(){
        slider.value = 0;
        slider.gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().color = new Color(255,0,0,1);
    }
}