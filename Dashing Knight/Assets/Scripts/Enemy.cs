using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(TouchingDirections))]
public class Enemy : MonoBehaviour
{

    public float walkSpeed = 3f;
    Rigidbody2D rb;
    TouchingDirections touchingDirections;

    public enum WalkableDirection { Right, left}
    private WalkableDirection _walkDirection;
    private Vector2 walkDirectionVector;

    public WalkableDirection WalkDirection {
        get 
        {
            return _walkDirection; 
        } 
        set 
        { 
            if (_walkDirection != value)
            {
                //direction flipped
                gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x*-1,gameObject.transform.localScale.y);

                if(value == WalkableDirection.Right)
                {
                    walkDirectionVector = Vector2.right;

                }else if(value== WalkableDirection.left)
                {
                    walkDirectionVector=Vector2.left;
                }

            }
            _walkDirection = value;
        }
    }   

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        touchingDirections = GetComponent<TouchingDirections>();
    }

    private void FixedUpdate()
    {
        
        if(touchingDirections.IsGrounded && touchingDirections.IsOnWall)
       {
           FlipDirection();
        }
        rb.velocity=new Vector2(walkSpeed* walkDirectionVector.x,rb.velocity.y);
        
    }

    private void FlipDirection()
    {
        if (WalkDirection == WalkableDirection.Right)
        {
            WalkDirection = WalkableDirection.left;
        }
        else if (WalkDirection == WalkableDirection.left)
        {
            WalkDirection = WalkableDirection.Right;
        }
        else
        {
            Debug.LogError("Current walkable direction isnt set to legal valz of rit or left");
        }
    }

    // Start is called before the first frame update
    
}
