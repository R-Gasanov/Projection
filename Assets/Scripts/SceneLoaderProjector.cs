using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderProjector : MonoBehaviour
{ // Here we will be loading on in the next scene for the character

    private bool playerTrigger = false;

    // Update is called once per frame
    void Update()
    {
        if (playerTrigger && Input.GetKeyDown(KeyCode.E))
        {
            ArcadeScene();
        }
    }

    // The function where we will load the next scene
    void ArcadeScene()
    {
        SceneManager.LoadScene("Level One");
    }

    // Here we will update whether or not the user is indeed by the projector or not

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerTrigger = true; // That means the player is indeed the trigger zone
        }  
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerTrigger = false;
        }
    }

}
