using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveX;
    private float moveY;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        moveX = 0;
        moveY = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.GetAxis("Mouse X") != 0)
        {
            moveX += Input.GetAxis("Mouse X");
        }
        if (Input.GetAxis("Mouse Y") != 0)
        {
            moveY += Input.GetAxis("Mouse Y");
        }


        rb.MovePosition(new Vector2(transform.position.x + moveX, transform.position.y + moveY));
        moveX = 0;
        moveY = 0;
    }
}
