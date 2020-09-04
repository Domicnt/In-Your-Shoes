using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public DialogueTrigger dialogueTrigger;
    public string sceneName;
    private bool changeScene;

    // Start is called before the first frame update
    void Start()
    {
        changeScene = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (changeScene)
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    // function for checking if the dialogue of the designated dialogueTrigger is done
    bool DialogueFinished()
    {
        if(dialogueManager.dial)
        return false;
    }
}
