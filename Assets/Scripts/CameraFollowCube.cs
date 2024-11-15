using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowCube : MonoBehaviour
{
    // variables specifically for movement
    public float maxSpeed; // --> Making it public means we can see it on the inspector
    // Below allows us to manipulate the 2D rigid body component (to help with movement)
    Rigidbody2D myRB;
    // Below allows us to manipulate the movement animation for the character
    Animator movement;

    bool facingRight;

    // Start is called before the first frame update
    void Start()
    { // Storing this component in myRB
        myRB = GetComponent<Rigidbody2D>();
        // Storing the animation in movement
        movement = GetComponent<Animator>();

        facingRight = true;

        // Below is to prevent the character from spinning around.
        myRB.freezeRotation = true; // I've added freeze constraint in the 2D Rigid Body but this is also a viable solution
    }

    // Physics engine operate after each fixed update
    void FixedUpdate()
    { // GetAxis --> Return a value between -1 and 1
        float move = Input.GetAxis("Horizontal"); // Axis are a predifined value in unity
        // Below is to add the animation -->


        // Mathf.Abs ensures we get an absalute value meaning a value between 0 and 1
        movement.SetFloat("speed", Mathf.Abs(move));

        // Add force to allow more realistic movement.
        myRB.velocity = new Vector2(move * maxSpeed, myRB.velocity.y); // Vector2 means 2D

        // Below us to make the character to turn

        if (move > 0 && !facingRight)
        { // The flip statement is used to change the directions of the character
            flip();
        }
        else if (move < 0 && facingRight)
        {
            flip();
        }


    } // GetRawAxis --> Only either -1, 0 OR 1

    void flip() // The function to ensure the character flips
    { //Changing directions
        facingRight = !facingRight;
        // Vector 3 is used as its the X, Y Z scale
        Vector3 theScale = transform.localScale; // Getting the scale from the current character's position
        // Reversing the character's position
        theScale.x *= -1; // Specifically the X only
        transform.localScale = theScale;
    }
}

