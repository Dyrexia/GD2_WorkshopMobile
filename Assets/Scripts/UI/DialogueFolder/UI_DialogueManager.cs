using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI DialogueText;
    private Queue<string> sentences;
    private float letterSpeed = 0.02f;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(UI_TutorialDialogue dialogueScript)
    {
        nameText.text = dialogueScript.nameOfNPC;

        sentences.Clear();

        foreach (string Phrase in dialogueScript.sentences)
        {
            sentences.Enqueue(Phrase);

        }
        DisplayNextPhrase();

    }
  public void DisplayNextPhrase ()
    {

        if (sentences.Count == 0) 
        {
            EndDialogue();
            return;
        
        }
        string Phrase =sentences.Dequeue();
        DialogueText.text = Phrase;
        StopAllCoroutines();
        StartCoroutine(TypePhrase(Phrase, letterSpeed));
    }

    IEnumerator TypePhrase (string Phrase, float letterSpeed)
    {
        DialogueText.text = "";
        foreach (char letter in Phrase.ToCharArray()) 
        { 
        DialogueText.text += letter;
            yield return new WaitForSeconds(letterSpeed);
            
        }
    }
    public void EndDialogue ()
    {
        Debug.Log("End Of Conversation ");
    }
}
