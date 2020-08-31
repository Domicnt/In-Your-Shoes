using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    // text objects in UI
    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    // a queue of all the sentences that will be displayed on the screen
    private Queue<string> sentences;
    
    // Start is called before the first frame update
    void Start()
    {
        // initializing the variable
        sentences = new Queue<string>();
    }

    public void startDialogue(Dialogue dialogue)
    {
        Debug.Log("starting dialogue with " + dialogue.name);
        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
        Debug.Log(sentence);
    }

    public void EndDialogue()
    {
        Debug.Log("End of conversation");
        animator.SetBool("IsOpen", false);
    }
}
