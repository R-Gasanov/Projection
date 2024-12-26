using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Used to see if the user ever inputted a key or not. If they have, (specifically escape) the games quits
        {
            Application.Quit();
        }
    }
}
