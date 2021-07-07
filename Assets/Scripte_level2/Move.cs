using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    //private Rigidbody2D rb;
    private float moveSpeed;
    private bool moveLeft, moveRight;

    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        moveSpeed = 5f;
        moveLeft = false;
        moveRight = false;

    }
    public void MoveLeft()
    {
        moveLeft = true;
    }
    public void MoveRight()
    {
        moveRight = true;
    }
    public void StopMoving()
    {
        moveLeft = false;
        moveRight = false;
        //rb.velocity = Vector2.zero;
    }
    private void Update()
    {
        if (moveLeft)
        {
            if (transform.position.x>-5.5f)
            {
                transform.Translate(Vector3.right * -1 * moveSpeed * Time.fixedDeltaTime);
            }
            
        }
        if (moveRight)
        {
            if (transform.position.x <6)
            {
                transform.Translate(Vector3.right * moveSpeed * Time.fixedDeltaTime);
            }    
        }
    }
}
