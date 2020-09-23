using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask lm;
    private Rigidbody2D rb;
    private BoxCollider2D bc2;
    private float moveX;
    private float moveY;
    public int walkAcceleration;
    public int maxWalkAcceleration;
    public float walkSpeed;
    public float fallSpeed;
    public float jumpSpeed;
    public bool jumping;
    public int jumpTimer;
    public int maxJumpTimer;
    public float jumpingPower;
    //public bool jumpCommitRight;
    //public bool jumpCommitLeft;
    //public bool falling;
    public int fallAcceleration;
    public int maxFallAcceleration;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        bc2 = this.GetComponent<BoxCollider2D>();
        moveX = 0;
        moveY = 0;
        walkAcceleration = 0;
        /*grounded = false;
        jumping = false;*/
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void FixedUpdate()
    {
        //Walking****************************************************************************
        if (Input.GetKey(KeyCode.D))
        {
            if(walkAcceleration < maxWalkAcceleration)
            {
                walkAcceleration++;
            }
            moveX += walkSpeed*walkAcceleration;
            /*if (jumping)
            {
                jumpCommitRight = true;
            }*/
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (walkAcceleration < maxWalkAcceleration)
            {
                walkAcceleration++;
            }
            moveX -= walkSpeed*walkAcceleration;
            /*if (jumping)
            {
                jumpCommitLeft = true;
            }*/
        }
        if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            walkAcceleration = 0;
        }
        //*************************************************************************************

        //Falling******************************************************************************
        if (!Grounded())
        {
            if (fallAcceleration < maxFallAcceleration)
            {
                fallAcceleration++;
            }
            moveY -= fallSpeed*fallAcceleration;
        }

        if(Grounded() && !Headbonk())
        {
            //falling = false;
            fallAcceleration = 1;
            //jumpCommitRight = false;
            //jumpCommitLeft = false;
        }
        //**************************************************************************************

        //Jumping*******************************************************************************
        if (Input.GetKeyDown(KeyCode.Space) && AlmostGrounded())
        {
            jumping = true;
            jumpTimer = maxJumpTimer;
        }
        if (jumping)
        {
            moveY += ((jumpSpeed * jumpTimer)*jumpingPower);
            jumpTimer--;
            if (jumpTimer == 0)
            {
                jumping = false;
            }

            if (Headbonk())
            {
                fallAcceleration = maxFallAcceleration;
                jumping = false;
            }
        }
        //**************************************************************************************

        //Positionupdate*************************************************************************
        rb.MovePosition(new Vector2(transform.position.x + moveX, transform.position.y + moveY));
        moveX = 0;
        moveY = 0;
    }

    private bool AlmostGrounded()
    {
        RaycastHit2D groundRay = Physics2D.BoxCast(bc2.bounds.center, bc2.bounds.size, 0f, Vector2.down, 0.5f, lm);

        return groundRay.collider != null;
    }

    private bool Grounded()
    {
        RaycastHit2D groundRay = Physics2D.BoxCast(bc2.bounds.center, bc2.bounds.size, 0f, Vector2.down, 0.1f, lm);

        return groundRay.collider != null;
    }

    private bool Headbonk()
    {
        RaycastHit2D headRay = Physics2D.BoxCast(bc2.bounds.center, bc2.bounds.size, 0f, Vector2.up, 0.1f, lm);

        return headRay.collider != null;
    }
    /*void OnTriggerEnter2D(Collider2D other)
    {
        grounded = true;
        //transform.position = new Vector2(transform.position.x, transform.position.y + 5);
        //Debug.Log("Collision!");
    }*/
}
