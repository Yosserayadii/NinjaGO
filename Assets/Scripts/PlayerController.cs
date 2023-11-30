using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D theRB;
    public float jumpForce;
    public float runSpeed;
    public float activeSpeed;
    public bool isGrounded;
    public Transform groundCheckPoint;
    public float groundCheckRaduis;
    public LayerMask whatIsGround;
    private bool canDoubleJump;
    public Animator anim;
    public float KnockBackLength, KnockBackSpeed;
    public float KnockBackCounter;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position,groundCheckRaduis,whatIsGround);
        //theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, theRB.velocity.y);
        //lets run faster when pressing keyshif :)
        if(KnockBackCounter <= 0) {
        activeSpeed = moveSpeed;
        if(Input.GetKey(KeyCode.LeftShift))
        {
            activeSpeed = runSpeed;
        }
        theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * activeSpeed, theRB.velocity.y);
        if (Input.GetButtonDown("Jump"))
        { if (isGrounded = true)
            {
                Jump();
                canDoubleJump =true;
                anim.SetBool("IsDoubleJumping", false);
            } else
            {
                if (canDoubleJump = true)
                {
                    Jump();
                    canDoubleJump = false;
                    anim.SetBool("IsDoubleJumping", true);
                }
            }
        
        }
        if(theRB.velocity.x > 0) {
            transform.localScale = Vector3.one;
        }
        if (theRB.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1f,1f,1f);
         }
        }
        else
        {
            KnockBackCounter -= Time.deltaTime;
            theRB.velocity=new Vector2(-KnockBackSpeed * transform.localScale.x, theRB.velocity.y);
        }
        //handle animations 
        anim.SetFloat("speed",Mathf.Abs( theRB.velocity.x));
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("ySpeed", theRB.velocity.y);
     }
    void Jump()
    {
        theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
        AudioManager.instance.PlaySFX(14);
    }
    public void KnockBack()
    {
        theRB.velocity = new Vector2(0f, jumpForce * .5f);
        anim.SetTrigger("IsKnokingBack");
        KnockBackCounter = KnockBackLength;
    }
}
