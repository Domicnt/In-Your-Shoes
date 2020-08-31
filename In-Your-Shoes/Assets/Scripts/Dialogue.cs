using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    // name of NPC
    public string name;

    // the sentences that will be loaded into the dialogueManager
    [TextArea(3,10)]
    public string[] sentences;
}
