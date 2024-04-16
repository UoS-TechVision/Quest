using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueActivate : MonoBehaviour
{
    public DialogueTrigger dialogueTrigger;
    // Start is called before the first frame update
    void Start()
    {
         dialogueTrigger.TriggerDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
