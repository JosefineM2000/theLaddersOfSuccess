using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rigidBody;
    public bool facingRight = true;
    private float speed = 7f;
    private float jumpForce = 15f;
    public LayerMask whatIsLadder;
    public LayerMask whatIsGround;

    private Rigidbody2D rb;
    private float inputHorizontal;
    private float inputVertical;
    public float distance = 5f;
    private float climbingSpeed = 3f;
    private bool isClimbing;

    ScoreCanvas score;
    public GameOver_CS gameOverUI;

    void Start()
    {
        anim = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>();
        score = GameObject.Find("ScoreCanvas").GetComponent<ScoreCanvas>();
    }

    // Update is called once per frame
    void Update()
    {
        Walking();
        CheckFlipping();
        Move();
        UpdateLaddarMovement();
        CheckJumping();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "ground")
        {
            anim.SetBool("standOnPlattform", true);
        } else
        {
            anim.SetBool("standOnPlattform", false);
        }
        if (collision.gameObject.name == "score_val")
        {
            score.AddPoints();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name == "DieBorder")
        {
            anim.SetBool("die", true);
            score.SetHighScore();
            gameOverUI.PlayerDead();
        }
    }
    
    void UpdateLaddarMovement()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(inputHorizontal * climbingSpeed, rb.velocity.y);

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsLadder);

        if (hitInfo.collider != null)
        {
            anim.SetBool("onLadder", true);
           if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
           {
                isClimbing = true;
           }
        }
        else
        {
            anim.SetBool("onLadder", false);
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                isClimbing = false;
            }
        }

        if (isClimbing == true && hitInfo.collider != null)
        {
            inputVertical = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(rb.velocity.x, inputVertical * climbingSpeed);
            rb.gravityScale = 0;
        }
        else
        {
            rb.gravityScale = 3;
        }
    }

    void CheckJumping()
    {
        if (Input.GetButtonDown("Jump") && (anim.GetBool("onLadder") || anim.GetBool("standOnPlattform")))
        {
            rigidBody.velocity = Vector2.up * jumpForce;
            anim.SetBool("jump", true);
        }
        else
        {
            anim.SetBool("jump", false);
        }
    }

    void CheckFlipping()
    {
        if (anim.GetBool("onLadder") == false && facingRight == false && (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
        {
            Flip();
            facingRight = true;
        }
        else if (anim.GetBool("onLadder") == false && facingRight == true && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)))
        {
            Flip();
            facingRight = false;
        }
    }

    void Walking()
    {
        if (anim.GetBool("standOnPlattform") == true && Input.GetAxisRaw("Horizontal") != 0)
        {
            anim.SetBool("walk", true);
        } else
        {
            anim.SetBool("walk", false);
        }
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        Vector2 pos = transform.position;
        pos.x += x * speed * Time.deltaTime;
        transform.position = pos;
    }

    void Flip()
    {
        Vector2 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
