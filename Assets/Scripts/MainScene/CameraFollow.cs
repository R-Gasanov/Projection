using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Here we will be making the camera follow the character
    public Transform Character;
    public float speedmove = 0.9f; //Creating the movement speed of the camera
    public Vector3 offset; // Ensuring the camera can be offset from the character


    // --> We will alos need the background boundaries to limite the camera
    public Transform Projection_background;
    Vector3 minBound; // --> Using Vector 3 as we have X, Y, Z axis
    Vector3 maxBound;

    //Assigning new variables for the camera boundaires

    float camHeight;
    float camWidth;
    // Establishing the min and max bounds of camera view

    // Start is called before the first frame update
    void Start()
    {
        // Below we will establish the zoom in and out size of the camera to capture more of the background

        // Here we will be setting up the camera, to ensure its operational

        Camera cam = Camera.main;
        camHeight = cam.orthographicSize;
        camWidth = cam.aspect * camHeight;



        // Will always be true as we have a background
        if (Projection_background != null)
        {
            // Will need to double check if the background asset has a renderer component <-- Remeber!
            SpriteRenderer backgroundSprite = Projection_background.GetComponent<SpriteRenderer>();
            if (backgroundSprite != null)
            {
                // Below we are establishing the boundaries of the Projection_Background sprite
                Vector3 bckgrndSize = backgroundSprite.bounds.size;
                Vector3 bckgrndPosition = Projection_background.position;


                // --> Setting the min and max bounds of the camera via the background position
                minBound = bckgrndPosition - (bckgrndSize / 2) + new Vector3(camWidth, camHeight, 0);
                maxBound = bckgrndPosition + (bckgrndSize / 2) - new Vector3(camWidth, camHeight, 0);
            }
        }
        
    }

    // Using LateUpdate as to prevent camera lag as to normal or FixedUpdate
    void FixedUpdate()
    {
        if (Character == null)
        {
            return;
        }

        // Creating the specific camera position based on the target position and offset

        Vector3 requiredPosition = Character.position + offset;
        Vector3 speedPosition = Vector3.Lerp(transform.position, requiredPosition, speedmove);

        // Attaching the camera position within the background's realms (also known as clamping)
        speedPosition.x = Mathf.Clamp(speedPosition.x, minBound.x, maxBound.x);
        speedPosition.y = Mathf.Clamp(speedPosition.y, minBound.y, maxBound.y);

        // Applying the relative speed of the position and the attachment of the position to the camera
        transform.position = speedPosition;
    }
}
