using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerPosition : MonoBehaviour
{ // --> I found an error where when you start a new session it'll load prior sessions values


    //private float currentY = 0f; // --> That is the relative height the character needs to be (ground)
    
    // Start is called before the first frame update
    void Start()
    {
        if (MainMenu.GameChecker != false)
        {
            if (PlayerPrefs.HasKey("CharacterX"))
            {
                float x = PlayerPrefs.GetFloat("CharacterX", transform.position.x);
                float y = PlayerPrefs.GetFloat("CharacterY", transform.position.y);
                // float y = PlayerPrefs.GetFloat("CharacterY", transform.position.y); Will always be constant
                transform.position = new Vector2(x, y);
            }
            else
            {
                Debug.Log("Base Spawn will occur.");
            }
        }
    }


}
