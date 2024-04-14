using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonTrigger : MonoBehaviour
{
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        button.gameObject.SetActive(false);   
    }

   private void OnTriggerEnter2D(Collider2D other)
    {
        button.gameObject.SetActive(true); 
    }

    private void OnTriggerExit2D(Collider2D collision) {
        button.gameObject.SetActive(false); 
    }
}
