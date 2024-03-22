using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class UI_DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI DialogueText;
    public Image ImageSpawn;
    private Queue<string> sentences;
    private Queue<Sprite> ImageLie;
    private float letterSpeed = 0.02f;
   [SerializeField] private string currentPhrase;
   [SerializeField] private bool PhraseComplete;
    public UI_HideShow DialogueCanva;
    public UI_HideShow MainMenu;
    public Image margaret;
    

    // Start is called before the first frame update
    void Awake()
    {
        sentences = new Queue<string>();
        ImageLie = new Queue<Sprite>();
    }

    public void StartDialogue(UI_TutorialDialogue dialogueScript)
    {
        nameText.text = dialogueScript.nameOfNPC;

        sentences.Clear();
        ImageLie.Clear();

        foreach (string Phrase in dialogueScript.sentences)
        {
            sentences.Enqueue(Phrase);
            Debug.Log(Phrase);

        }
        foreach (Sprite image in dialogueScript.tutorialImage)
        {
            ImageLie.Enqueue(image);
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
            Debug.Log("j'accèlere");
            PhraseComplete = true;

         }

    }
  public void DisplayNextPhrase ()
    {
        nameText.text = "Margaret";
        margaret.gameObject.SetActive(true);
        PhraseComplete = false;
       
        if (sentences.Count == 0) 
        {
            EndDialogue();
            return;
        
        }

     
      
        string Phrase = sentences.Dequeue();
        if (Phrase == "*Quelques semaines plus tard*")
        {
            nameText.text = "";
          margaret.gameObject.SetActive(false);
        }
        DialogueText.text = Phrase;
        currentPhrase = Phrase;
        Sprite Image = ImageLie.Dequeue();
        ImageSpawn.sprite = Image;

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
      DialogueCanva.HideCanvas();
      MainMenu.ShowCanvas();
    }
}
