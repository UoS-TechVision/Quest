using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public bool isInRange;
    public UnityEvent interactAction;
    public GameObject myButton;

    void Update()
    {
        if(isInRange){
            myButton.SetActive(true);
        }

        else{
            myButton.SetActive(false);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            Debug.Log("Player in range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       if(collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            Debug.Log("Player not in range");
        } 
    }
}
