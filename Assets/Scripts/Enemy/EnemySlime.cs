using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlime : Enemy
{
    private Rigidbody2D myRigidbody;
    private Animator myAnim;
    public Transform leftpoint, rightpoint;

    public float enemySpeed;
    private float leftx, rightx;
    private bool isFacingLeft = true;

    // Start is called before the first frame update
    public void Start()
    {
        base.Start();
        myAnim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        transform.DetachChildren();
        leftx = leftpoint.position.x;
        rightx = rightpoint.position.x;
        Destroy(leftpoint.gameObject);
        Destroy(rightpoint.gameObject);
    }

    // Update is called once per frame
    public void Update()
    {
        base.Update();
        Movement();
    }

    private void Movement()
    {
        myAnim.SetBool("Move", true);
        if(isFacingLeft)
        {
            myRigidbody.velocity = new Vector2(-enemySpeed, myRigidbody.velocity.y);
            if(transform.position.x < leftx)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                isFacingLeft = false;
            }    
        }
        else
        {
            myRigidbody.velocity = new Vector2(enemySpeed, myRigidbody.velocity.y);
            if(transform.position.x > rightx)
            {
                transform.localScale = new Vector3(1, 1, 1);
                isFacingLeft = true;
            }
        }
    }
}
