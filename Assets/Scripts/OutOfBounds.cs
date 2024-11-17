using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Used to change into different scenes

public class OutOfBounds : MonoBehaviour
{ // Okay, so based on what I've learned creating the SceneLoadProjector C#

    // Here if the player goes out of the background scene it will atomatically be ejected out of the scene

    private bool PlayerInBound = true;

    void Update()
    {
        if (PlayerInBound == false)
        { // --> In a future update I'll add a screen to show the player lost the level

            // If the player is indeed out of the bound of 
            EjectScene();
        }
    }

    // --> The function used to eject the player back into the main scene
    void EjectScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    // --> The checker to see if the user has indeed left the scene
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerInBound = false;
        }
    }
}
