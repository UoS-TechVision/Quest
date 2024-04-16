using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueActivate : MonoBehaviour
{
    public DialogueTrigger dialogueTrigger;

    void Start()
    {
        StartCoroutine(TriggerDialogueWithDelay());
    }

    IEnumerator TriggerDialogueWithDelay()
    {
        yield return new WaitForSeconds(1.0f); // Adjust the delay time as needed
        dialogueTrigger.TriggerDialogue();
    }
}
