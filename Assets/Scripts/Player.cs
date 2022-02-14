using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rigidBody;
    private BoxCollider2D boxCollider2d;
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

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
        score = GameObject.Find("ScoreCanvas").GetComponent<ScoreCanvas>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckJumping();
        Walking();
        CheckFlipping();
        Move();
        UpdateLaddarMovement();
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
            isClimbing = true;
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

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, .1f, whatIsGround);
        return raycastHit2d.collider != null;
    }

    private bool IsLadder()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, .1f, whatIsLadder);
        return raycastHit2d.collider != null;
    }

    void CheckJumping()
    {
        if ((IsGrounded() || IsLadder() ) && Input.GetKeyDown(KeyCode.Space))
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
