using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{ // --> Here will be the mainMenu of the Game

    public GameObject Menu;
    public GameObject Character;

    // --> Will be the player's original position
    private Vector2 defaultposition;


    // To prevent the main menu from occuring over and over again
    public static bool GameChecker = false;

    // Start is called before the first frame update
    void Start()
    { // --> Freezing the game since you haven't player yet

        PlayerPrefs.DeleteKey("CharacterX");
        PlayerPrefs.DeleteKey("CharacterY");
        PlayerPrefs.Save();

        if (GameChecker == false)
        {
            Time.timeScale = 0;


            // Assiging the variable with the actual player's position

            defaultposition = Character.transform.position;
            GameChecker = true;
        }
        else
        {
            Menu.SetActive(false);

            Debug.Log("Game has already started no need for menu.");
        }

    }

    public void PressStart()
    { // Removing the saved location from prior runs

        // Reseting the current location now
        Character.transform.position = defaultposition;

        // --> Now we can start the game again
        Time.timeScale = 1;
        Menu.SetActive(false);


        // --> Just to clarify to the coder that the game is indeed working

        Debug.Log("Game started! Huzzah!");

    }

    // --> If the player chooses to quit
    public void PressExit()
    {
        Debug.Log("Exiting game...");
        Application.Quit(); // --> Forcefully ends the game
    }
}
