using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    private Queue<string> sentences;

    // variable for if the DialogueManager is actually producing text at this moment
    public bool texting;
    public bool finishedTexting;
    // variable storing the object that triggered the dialogue
    public GameObject trigger;
    public GameObject pastTrigger;
    

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        texting = false;
    }

    public void StartDialogue(Dialogue dialogue, GameObject trigger)
    {
        texting = true;
        finishedTexting = false;
        this.trigger = trigger;
        pastTrigger = trigger;

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
        StopAllCoroutines();
    }

    public void EndDialogue()
    {
        texting = false;
        finishedTexting = true;
        trigger = null;
        animator.SetBool("IsOpen", false);
    }
}
