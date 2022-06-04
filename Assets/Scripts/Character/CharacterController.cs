using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    private Animator myAnim;
    private BoxCollider2D myBoxCollider;
    public float jumpSpeed = 5f;
    public float runSpeed = 5f;

    bool isFacingRight = true;
    private bool isGround;

    Vector2 velocity;

    // Start is called before the first frame update
    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        myBoxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(velocity.x > 0 && isFacingRight == false)
        {
            Flip();
        }
        else if(velocity.x < 0 && isFacingRight == true)
        { 
            Flip();
        }
    }
    
    private void FixedUpdate()
    {
        Jump();
        Run();
        UpdateAnimations();
    }
    
    void CheckGrounded()
    {
        isGround = myBoxCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));
    }

    //Character Flip
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    //Character Run
    private void Run()
    {
        velocity.x = Input.GetAxis("Horizontal");
        myRigidbody.MovePosition(myRigidbody.position + velocity * runSpeed * Time.fixedDeltaTime);
    }

    //Character Jump
    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(isGround)
            {
                    
                    myAnim.SetBool("Jump", true);
                    /* jumpAudio.Play(); */
                    Vector2 jumpVel = new Vector2(0.0f, jumpSpeed);
                    myRigidbody.velocity = Vector2.up * jumpVel;
                    
            }
            
        }
    }

    //Character Animations
    private void UpdateAnimations()
    {
        if(Mathf.Abs(velocity.x) > 0.1f)
        {
            myAnim.SetBool("Run", true);
        }
        else
        {
            myAnim.SetBool("Run", false);
        }

        if(Mathf.Abs(velocity.y) > 0.1f)
        {
            myAnim.SetBool("Jump", true);
        }
        else
        {
            myAnim.SetBool("Jump", false);
        }
    }
}
