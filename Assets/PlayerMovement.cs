using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask lm;
    private Rigidbody2D rb;
    public BoxCollider2D bc2;
    private float moveX;
    private float moveY;
    public float walkSpeed;
    public float fallSpeed;
    public float jumpSpeed;
    public bool jumping;
    public int jumpTimer;
    public int maxJumpTimer;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        bc2 = this.GetComponent<BoxCollider2D>();
        moveX = 0;
        moveY = 0;
        /*grounded = false;
        jumping = false;*/
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            moveX += walkSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveX -= walkSpeed;
        }

        if (!Grounded())
        {
            moveY -= fallSpeed;
        }

        if (Input.GetKeyDown(KeyCode.Space) && AlmostGrounded())
        {
            jumping = true;
            jumpTimer = maxJumpTimer;
        }
        if (jumping)
        {
            jumpTimer--;
            moveY += jumpSpeed;
        }
        if (jumpTimer == 0)
        {
            jumping = false;
        }

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

    /*void OnTriggerEnter2D(Collider2D other)
    {
        grounded = true;
        //transform.position = new Vector2(transform.position.x, transform.position.y + 5);
        //Debug.Log("Collision!");
    }*/
}
