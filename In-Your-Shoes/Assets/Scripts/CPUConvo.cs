using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPUConvo : MonoBehaviour
{
    public GameObject player;
    public DialogueTrigger dialogueTrigger;
    private int hasTalked;

    // Start is called before the first frame update
    void Start()
    {
        hasTalked = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float distFromPlayer = Vector2.Distance(player.transform.position, this.transform.position);
        if (distFromPlayer <= 5 && hasTalked == 0)
        {
            hasTalked = 1;
            Debug.Log("close enough");
            dialogueTrigger.TriggerDialogue();
        }
    }
}
