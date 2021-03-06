﻿
using UnityEngine;

public class DragFingerMove : MonoBehaviour
{
    private Vector3 touchPosition;
    private Rigidbody2D rb;
    private float direction;        //direction must be vector2 if y axis control is required
    public float moveSpeed = 10f;
    private float yAxis,xAxis;

    // Use this for initialization
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);    //get first finger
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;
            yAxis = rb.position.y;  //postion of harambe
            xAxis = rb.position.x;
            if (touchPosition.x < xAxis + 0.5f && touchPosition.x > xAxis - 0.5f && touchPosition.y < yAxis + 0.5f && touchPosition.y > yAxis - 0.5f) //check if the player is touching the object
            {
                ///for both x and y
                //direction = (touchPosition - transform.position);
                //rb.velocity = new Vector2(direction.x, direction.y) * moveSpeed;

                //if (touch.phase == TouchPhase.Ended)
                //    rb.velocity = Vector2.zero;

                direction = (touchPosition.x - transform.position.x);
                rb.velocity = new Vector2(direction, transform.position.y) * moveSpeed;
                if(touchPosition.y>yAxis+0.3f|| touchPosition.y < yAxis - 0.3f||touch.phase==TouchPhase.Ended) //movement will be cancelled if player moves out of harambe
                {
                    rb.velocity = Vector2.zero;
                }
            }
            else
            {
                print("error not matching");
            }
            
        }
    }
}
