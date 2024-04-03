using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(TouchingDirections), typeof(Damageable))]
public class EnemyAI : MonoBehaviour
{

    public float walkSpeed = 3f;
    public float walkStopRate = 0.05f;
    public DetectionZone attackZone;

    Rigidbody2D rb;
    TouchingDirections touchingDirections;
    Animator animator;
    Damageable damageable;
    

    public enum WalkableDirection { Right, left }

    private WalkableDirection _walkDirection;

    private Vector2 walkDirectionVector=Vector2.right;

    public WalkableDirection WalkDirection
    {
        get
        {
            return _walkDirection;
        }
        set
        {
            if (_walkDirection != value)
            {
                //direction flipped
                gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);

                if (value == WalkableDirection.Right)
                {
                    walkDirectionVector = Vector2.right;

                }
                else if (value == WalkableDirection.left)
                {
                    walkDirectionVector = Vector2.left;
                }
            }
            _walkDirection = value;
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        touchingDirections = GetComponent<TouchingDirections>();
        animator = GetComponent<Animator>();
        damageable = GetComponent<Damageable>();
    }

    public bool _hasTarget = false;


    public bool HasTarget {  get { return _hasTarget; } 
        private set
        {

            _hasTarget = value;
            animator.SetBool(AnimationStrings.hasTarget,value);
        }
    }

    public bool CanMove {  
        get 
        { 
            return animator.GetBool(AnimationStrings.canMove); 
        
        }
    }

  


    private void FixedUpdate()
    {

        if (touchingDirections.IsGrounded && touchingDirections.IsOnWall)
        {
            FlipDirection();
        }
        if(!damageable.LockVelocity)
        {

            if (CanMove)
            
                rb.velocity = new Vector2(walkSpeed * walkDirectionVector.x, rb.velocity.y);
            
            else
            
                rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x, 0, walkStopRate), rb.velocity.y);
            
        }
       
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

    public void OnHit(int damage, Vector2 knockback)
    {
       
        rb.velocity = new Vector2(knockback.x, rb.velocity.y + knockback.y);
    }
   
    // Start is called before the first frame update

}