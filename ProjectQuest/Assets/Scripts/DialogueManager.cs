using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Animator animator;
    private Queue<string> sentences;
    private Queue<string> names;
    // Start is called before the first frame update
    void Start() {
        sentences = new Queue<string>();
        names = new Queue<string>();
    }

    public void StartDialogue (Dialogue dialogue) {
        animator.SetBool("isOpen", true);
        sentences.Clear();
        names.Clear();

        foreach (var name in dialogue.names) {
            names.Enqueue(name);
        }

        foreach (var sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence() {
        if (sentences.Count == 0 || names.Count == 0) {
            EndDialogue();
            return;
        }
        
        string sentence = sentences.Dequeue();
        string name = names.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence, name));
    }

    IEnumerator TypeSentence(string sentence, string name) {
        dialogueText.text = "";
        nameText.text = name;
        foreach (char letter in sentence.ToCharArray()) {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue() {
        animator.SetBool("isOpen", false);
        Debug.Log("End of conversation");
    }
}