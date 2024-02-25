using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterContollerScript : MonoBehaviour
{
    // moving
    public float maxSpeed;
    public float acceleration;
    public Rigidbody2D myRb;
    
    // jumping
    public bool isGrounded;
    public float jumpForce;
    
    // holding jump - jump higher
    public float secondaryJumpForce;
    public float secondaryJumpTime;
    public bool isSecondaryJump;
    public Animator anim;
    
    void Start()
    {
        myRb = GetComponent<Rigidbody2D>(); // look for a component called RigidBody 2d and assign it to myRb
        anim = GetComponentInChildren<Animator>();
    }

    // Update G>()etComponentInChildrem<is called once per frame
    void Update()
    {
        anim.SetFloat("speed", Mathf.Abs(myRb.velocity.x)); // set the speed parameter in the animator to the absolute value of the velocity of the rigidbody
        // Check if the absolute value of the horizontal input axis is greater than 0.1,
        // indicating that the player is actively moving left or right beyond a small threshold.
        // Mathf.Abs is used to ensure that negative and positive values are treated equally.
        // Input.GetAxis("Horizontal") returns a value between -1 and 1 based on the player's input.
        // Additionally, check if the absolute value of the current velocity of the Rigidbody (myRb)
        // along the x-axis is less than maxSpeed, ensuring that the Rigidbody's velocity is within acceptable limits.
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f && Mathf.Abs(myRb.velocity.x) < maxSpeed)
        {
            // If the condition is met, add a force to the Rigidbody (myRb) to move it horizontally.
            // The force applied is proportional to the player's input along the horizontal axis (Input.GetAxis("Horizontal")),
            // multiplied by a predefined acceleration factor (acceleration), and oriented along the x-axis (0 for the y-axis).
            // This force is added using AddForce, specifying the force as a Vector2 (horizontal force, 0 for vertical force).
            // ForceMode2D.Force ensures that the force is applied continuously, simulating a smooth acceleration.
            myRb.AddForce(new Vector2(Input.GetAxis("Horizontal") * acceleration, 0), ForceMode2D.Force); 
        }
        // ========================  JUMP CODE
        if (isGrounded && Input.GetButtonDown("Jump")) // if the player is grounded and the jump button is pressed
        {
            myRb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse); // add a force in the Y direction
            StartCoroutine(SecondaryJump());
        }

        if (isGrounded == false && Input.GetButton("Jump") && isSecondaryJump)
        {
            myRb.AddForce(new Vector2(0, secondaryJumpForce), ForceMode2D.Force); // while the jump button is held, add a force in the Y direction
        }
        // ======================= END JUMP CODE
    }

    // as long as a collider is detected inside the trigger, the player is grounded
    private void OnTriggerStay2D(Collider2D other)
    {
        isGrounded = true;
    }
    // when the collider exits the trigger, the player is no longer grounded
    private void OnTriggerExit2D(Collider2D other)
    {
        isGrounded = false;
    }
    
    // COROUTINE FOR HOLDING JUMP
    IEnumerator SecondaryJump()
    {
        isSecondaryJump = true;
        yield return new WaitForSeconds(secondaryJumpTime);
        isSecondaryJump = false;
        yield return null;
    }
}
