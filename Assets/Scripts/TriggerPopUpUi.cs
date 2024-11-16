using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPopUpUi : MonoBehaviour
{ // Assigning a public variable and be sure to drag it there
    public GameObject PopUp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Assigned the player tag so it should be the character
        {
            PopUp.SetActive(true); // It'll activate the image that's been deactivated
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PopUp.SetActive(false);
        }
    }
}
