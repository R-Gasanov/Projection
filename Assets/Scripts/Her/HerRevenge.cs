using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerRevenge : MonoBehaviour
{
    
    private GameObject gameOverScreen;

    public void Start()
    {
        GameObject mainCamera = GameObject.Find("Main Camera");

        if (mainCamera != null)
        {
            gameOverScreen = mainCamera.transform.Find("GameOverScreen")?.gameObject;
            if (gameOverScreen != null)
            {
                gameOverScreen.SetActive(false);
            }
        }
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {

            if (gameOverScreen != null)
            {
                // --> Freezing the game
                Time.timeScale = 0f;
                gameOverScreen.SetActive(true);
            }
        }
    }
}
