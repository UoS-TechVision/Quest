using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public bool isInRange;
    public GameObject myButton;
    public Collider2D puzzleCollider;

    void OnTriggerEnter2D(Collider2D collision)
    {
        puzzleCollider.isTrigger = true;
        Debug.Log("Entered collision with " + collision.gameObject.name);
        isInRange = true;
    }

    // Gets called when the object exits the collision
    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exited collision with " + collision.gameObject.name);
        isInRange = false;
    }

    void Update()
    {
        if(isInRange){
            myButton.SetActive(true);
        }

        else{
            myButton.SetActive(false);
        }
        
    }
}

