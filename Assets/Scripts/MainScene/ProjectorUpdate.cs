using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectorUpdate : MonoBehaviour
{
    // Below are the variables to set the new change of variables for the next levels

    public GameObject Idle_Projector_01; // --> The current Object that is active
    public GameObject On_Projector_01; // --> The current object that is inactive


    // Start is called before the first frame update
    private void Start()
    { // Checking if the CompleteLevel is true and we do indeed have those GameObjects
        if (LevelCompleteLoader.CompleteLevel && Idle_Projector_01 != null && On_Projector_01 != null)
        { // Above we're having to go through the other script LevelCompleteLoader to find if it has completed the level or not
            Idle_Projector_01.SetActive(false); // --> Turning off one object
            On_Projector_01.SetActive(true); // --> Whilst turning on the other one making visible
        }
    }
}
