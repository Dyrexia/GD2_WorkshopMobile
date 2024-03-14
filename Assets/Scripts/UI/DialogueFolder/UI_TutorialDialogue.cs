using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UI_TutorialDialogue 
{
    public string nameOfNPC;

    [TextArea(3,10)]
    public string[] sentences;

}
