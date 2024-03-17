using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
//using UnityEngine.UI;
using UnityEngine.UIElements;

public class UI_DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI DialogueText;
    //public Image ImageSpawn;
    private Queue<string> sentences;
  //  private Queue<Sprite> ImageLi�;
    private float letterSpeed = 0.05f;
   [SerializeField] private string currentPhrase;
   [SerializeField] private bool PhraseComplete;
    
   

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
       // ImageLi� = new Queue<Sprite>();
    }

    public void StartDialogue(UI_TutorialDialogue dialogueScript)
    {
        nameText.text = dialogueScript.nameOfNPC;

        sentences.Clear();
       // ImageLi�.Clear();

        foreach (string Phrase in dialogueScript.sentences)
        {
            sentences.Enqueue(Phrase);

        }
     //   foreach (Sprite image in dialogueScript.tutorialImage)
        {
      //      ImageLi�.Enqueue(image);
        }
        DisplayNextPhrase();

    }

    public void PhraseVerification ()
    {   

        if (PhraseComplete is true)
        {
           
            DisplayNextPhrase ();

        }

        else
        {
            StopAllCoroutines();
            DialogueText.text = currentPhrase;
            Debug.Log("j'acc�lere");
            PhraseComplete = true;

         }

    }
  public void DisplayNextPhrase ()
    {
        PhraseComplete = false;
       
        if (sentences.Count == 0) 
        {
            EndDialogue();
            return;
        
        }
      
        string Phrase = sentences.Dequeue();
        DialogueText.text = Phrase;
        currentPhrase = Phrase;
       // Sprite Image = ImageLi�.Dequeue();
      //  ImageSpawn.sprite = Image;

        StopAllCoroutines();
        StartCoroutine(TypePhrase(Phrase, letterSpeed));

    }

    IEnumerator TypePhrase (string Phrase, float letterSpeed)
    {
        PhraseComplete = false;
        DialogueText.text = "";
        
        foreach (char letter in Phrase.ToCharArray()) 
        { 
        DialogueText.text += letter;
            yield return new WaitForSeconds(letterSpeed);  
        }
        PhraseComplete= true;
        Debug.Log(PhraseComplete);
    }
    public void EndDialogue ()
    {
        Debug.Log("End Of Conversation ");
    }
}
