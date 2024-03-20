using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool isInRangeType1 = false;
    public bool isInRangeType2 = false;
    public GameObject buttonType1; // Reference to the first button
    public GameObject buttonType2; // Reference to the second button

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check for the type of collider and set the appropriate flag
        if (collision.gameObject.CompareTag("puzzleCollisionBox"))
        {
            Debug.Log("Entered collision with " + collision.gameObject.name);
            isInRangeType1 = true;
        }
        else if (collision.gameObject.CompareTag("safeCollisionBox"))
        {
            Debug.Log("Entered collision with " + collision.gameObject.name);
            isInRangeType2 = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        // Reset the flag when exiting the collider
        if (collision.gameObject.CompareTag("puzzleCollisionBox"))
        {
            Debug.Log("Exited collision with " + collision.gameObject.name);
            isInRangeType1 = false;
        }
        else if (collision.gameObject.CompareTag("safeCollisionBox"))
        {
            Debug.Log("Exited collision with " + collision.gameObject.name);
            isInRangeType2 = false;
        }
    }

    void Update()
    {
        // Activate or deactivate buttons based on the current state
        if (isInRangeType1)
        {
            buttonType1.SetActive(true);
        }
        else
        {
            buttonType1.SetActive(false);
        }

        if (isInRangeType2)
        {
            buttonType2.SetActive(true);
        }
        else
        {
            buttonType2.SetActive(false);
        }
    }
}
