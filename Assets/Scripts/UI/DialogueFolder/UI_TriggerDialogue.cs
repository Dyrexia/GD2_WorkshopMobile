using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_TriggerDialogue : MonoBehaviour
{
    public UI_TutorialDialogue dialogue= new UI_TutorialDialogue();

    public void TriggerDialogue()
    {
        FindObjectOfType<UI_DialogueManager>().StartDialogue(dialogue);
    }
}
