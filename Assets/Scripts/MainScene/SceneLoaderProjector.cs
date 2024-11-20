using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderProjector : MonoBehaviour
{ // Here we will be loading on in the next scene for the character

    private bool playerTrigger = false;

    // --> Below we are saving the position of player

    public void PositionSave(Vector2 position) // Taking in Vectors only
    {
        PlayerPrefs.SetFloat("CharacterX", position.x);
        //PlayerPrefs.SetFloat("CharacterY", position.y); The y axis is always constant
        PlayerPrefs.Save();
    }

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
    { // --> Just before we head to the new scene, we will save the position of the player
        PositionSave(transform.position);
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
