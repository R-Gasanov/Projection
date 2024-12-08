using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Used to change into different scenes

public class SpikeCollider : MonoBehaviour
{
    private bool playerTrigger = false; // --> Will hit true when the player hits the obstacle


    // Similar to the out of bounds, instead of leaving the bounds, here is when the bounds collide instead

    public GameObject EndScreen; // --> Remember! The public will always allow us to drag the object within the inspector for future reference
    public float displayDuration = 3f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerTrigger = true;
            ShowEndScreen();
        }
    }

    void Update()
    {
        if (playerTrigger == true)
        {
            StartCoroutine(ShowEndScreen());
        }
    }

    // IEnumerator = a couroutine method, which apparently allows multiple frames for code execution, which works for the showing image 3 seconds

    // yield return especially delays the supposed action over the series of frames and then given the speicifc time which was done with the float above
    private IEnumerator ShowEndScreen()
    {
        if (EndScreen != null)
        {
            EndScreen.SetActive(true);
        }
        yield return new WaitForSeconds(displayDuration);

        failedLevel();
    }


    void failedLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
