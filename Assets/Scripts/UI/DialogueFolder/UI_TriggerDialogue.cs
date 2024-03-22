using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_TriggerDialogue : MonoBehaviour
{
    public UI_TutorialDialogue dialogue;

    //private void OnEnable()
    //{
       
    //    TriggerDialogue();
    //    Debug.Log("J'envoie trigger dialogue");
    //}

    public void TriggerDialogue()
    {
        FindObjectOfType<UI_DialogueManager>().StartDialogue(dialogue);
    }
}
