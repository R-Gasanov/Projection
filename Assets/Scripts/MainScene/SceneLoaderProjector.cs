using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderProjector : MonoBehaviour
{ // Here we will be loading on in the next scene for the character

    private bool playerTrigger = false;

    // --> Below is the checker of which level your on

    // --> Irregardless what projector you do first, levels are based on which projector you do first

    // --> Here is a public static class, it'll help us allow edits to occur to and from other scripts
    public static class CurrentLevel
    {
        public static float LvlCount = 1;
    }
    
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
        if (CurrentLevel.LvlCount == 1)
        {
            SceneManager.LoadScene("Level One");
        }
        else if (CurrentLevel.LvlCount == 2)
        {
            SceneManager.LoadScene("Level Two");
        }
        else if (CurrentLevel.LvlCount == 3)
        {
            SceneManager.LoadScene("Level Three");
        }
        else if (CurrentLevel.LvlCount == 4)
        {
            SceneManager.LoadScene("Level Four");
        }
        else if (CurrentLevel.LvlCount == 5)
        {
            SceneManager.LoadScene("Level Five");
        }
        
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
