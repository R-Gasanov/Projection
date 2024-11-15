using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowCube : MonoBehaviour
{
    // Here we will be making the camera follow the character
    public Transform Character;
    public float speedmove = 0.9f; //Creating the movement speed of the camera
    public Vector3 offset; // Ensuring the camera can be offset from the character

    // Start is called before the first frame update
    private void FixedUpdate()
    {
        if (Character == null)
        {
            return;
        }
        // Grabs the position of the character based on its current position plus the offset if added
        Vector3 wantedPos = Character.position + offset;
        Vector3 movePos = Vector3.Lerp(transform.position, wantedPos, speedmove);
        // Alters it as the position changes whilst having the speed as well
        transform.position = movePos;
        // Then transforms it to the currently moved position
        
    }
}
