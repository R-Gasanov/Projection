using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectorUpdate : MonoBehaviour
{
    // Below are the variables to set the new change of variables for the next levels

    public GameObject Idle_Projector_01; // --> The current Object that is active
    public GameObject On_Projector_01; // --> The current object that is inactive
    public GameObject Idle_Projector_02;
    public GameObject On_Projector_02;
    public GameObject Idle_Projector_03;
    public GameObject On_Projector_03;
    public GameObject Idle_Projector_04;
    public GameObject On_Projector_04;
    public GameObject Idle_Projector_05;
    public GameObject On_Projector_05;

    // When the person finally turns on all the projectors within the game
    public GameObject VictoryScreen;


    // Start is called before the first frame update
    private void Start()
    { // Checking if the CompleteLevel is true and we do indeed have those GameObjects
        Debug.Log("The current Lvlcount is " + SceneLoaderProjector.CurrentLevel.LvlCount);
        if (LevelCompleteLoader.CompleteLevel && Idle_Projector_01 != null && On_Projector_01 != null && SceneLoaderProjector.CurrentLevel.LvlCount >= 2)
        { // Above we're having to go through the other script LevelCompleteLoader to find if it has completed the level or not
            Idle_Projector_01.SetActive(false); // --> Turning off one object
            On_Projector_01.SetActive(true); // --> Whilst turning on the other one making visible
            HerSpawn.SpawnChance = 0.3f;
            HerMovement.speed = 16f;
        }
        if (LevelCompleteLoader.CompleteLevel && Idle_Projector_02 != null && On_Projector_01 != null && SceneLoaderProjector.CurrentLevel.LvlCount >= 3)
        { // The next set of projectors.
            Idle_Projector_02.SetActive(false);
            On_Projector_02.SetActive(true);

            // We are slowly scaling her difficulty to make the game more harder
            HerSpawn.SpawnChance = 0.4f;
            HerMovement.speed = 18f;

        }
        if (LevelCompleteLoader.CompleteLevel && Idle_Projector_03 != null && On_Projector_03 != null && SceneLoaderProjector.CurrentLevel.LvlCount >= 4)
        { // --> The level will become excessively more difficult as time goes on
            Idle_Projector_03.SetActive(false);
            On_Projector_03.SetActive(true);

            // Just making the game harder to ensure the player has to deal with the boss
            /*
            HerSpawn.SpawnChance = 0.2f;
            HerMovement.speed = 12f;
            */


            HerSpawn.SpawnChance = 0.5f;
            HerMovement.speed = 20f;
        }
        if (LevelCompleteLoader.CompleteLevel && Idle_Projector_04 != null && On_Projector_04 != null && SceneLoaderProjector.CurrentLevel.LvlCount >= 5)
        {
            Idle_Projector_04.SetActive(false);
            On_Projector_04.SetActive(true);

            /*
            HerSpawn.SpawnChance = 0.3f;
            HerMovement.speed = 16f;
            */

            HerSpawn.SpawnChance = 0.6f;
            HerMovement.speed = 24f;

        }
        if (LevelCompleteLoader.CompleteLevel && Idle_Projector_05 != null && On_Projector_05 != null && SceneLoaderProjector.CurrentLevel.LvlCount >= 6)
        {
            Idle_Projector_05.SetActive(false);
            On_Projector_05.SetActive(true);

            Victory();
        }

        void Victory()
        {
            Time.timeScale = 0f;
            VictoryScreen.SetActive(true);
        }

        //else if (LevelCompleteLoader.CompleteLevel && Idle_)
    }
}
