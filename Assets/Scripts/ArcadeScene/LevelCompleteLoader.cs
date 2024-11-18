using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteLoader : MonoBehaviour
{ // Similar to the OutOfBounds script, here it'll also take the player back to the start
    // Start is called before the first frame update

    private bool PlayerLvlComplete = false; // --> The checker to see if the player completed the level

    public static bool CompleteLevel = false; // --> The checker if that level is completed


    // Update is called once per frame
    void Update()
    {
        if (PlayerLvlComplete == true)
        {
            CompletedLvl();
        }
    }

    void CompletedLvl()
    { // --> Will active once the level is compelted

        CompleteLevel = true; // Updating the condition for the start
        SceneManager.LoadScene("SampleScene");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { // If it hits the collider then the player returns back
        if (collision.CompareTag("Player"))
        {
            PlayerLvlComplete = true;
        }
    }
}
