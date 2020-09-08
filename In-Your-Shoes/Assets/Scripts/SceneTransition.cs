using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public GameObject sceneChanger;
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
        DialogueFinished();
        if (changeScene)
        {
            SceneManager.LoadScene(sceneName: sceneName);
        }
    }

    // function for checking if the dialogue of the designated dialogueTrigger is done
    bool DialogueFinished()
    {
        if (dialogueManager.pastTrigger == sceneChanger && dialogueManager.finishedTexting == true) {
            print("the dialogue trigger is the same as the scene changer object");
            changeScene = true;
        }
        return false;
    }
}
