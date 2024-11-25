using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteLoader : MonoBehaviour
{ // Similar to the OutOfBounds script, here it'll also take the player back to the start
    // Start is called before the first frame update

    private bool PlayerLvlComplete = false; // --> The checker to see if the player completed the level

    public static bool CompleteLevel = false; // --> The checker if that level is completed

    // --> Below we are assigning the image that will represent that you've completed the level
    public GameObject CompleteScreen;
    public float displayDuration = 3f; // --> The duration that image will stay up till we change scenes

    

    public SceneLoaderProjector SceneLoaderProj;

    // Update is called once per frame
    void Update()
    {
        if (PlayerLvlComplete == true)
        {
            StartCoroutine(ShowCompleteScreen());
        }
    }
    // --> Us showing the image through this function

    private IEnumerator ShowCompleteScreen()
    {
        PlayerLvlComplete = false; // --> Prevent multiple triggers
        if (CompleteScreen != null)
        {
            CompleteScreen.SetActive(true);
        }

        yield return new WaitForSeconds(displayDuration); // --> Showing the image based on the time provided

        CompletedLvl();
    }

    void CompletedLvl()
    { // --> Will active once the level is compelted


        //--> Here we will add on an additional value to help get to the next level
        SceneLoaderProjector.CurrentLevel.LvlCount = SceneLoaderProjector.CurrentLevel.LvlCount + 1;
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
