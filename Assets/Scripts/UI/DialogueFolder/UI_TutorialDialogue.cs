using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class UI_TutorialDialogue 
{
    public string nameOfNPC;

    [TextArea(3, 10)]
    public string[] sentences =
    {
     "Le texte marche",
     "ENfin putain je deviens fou",


    };
    public Sprite[] tutorialImage;

    
    

   

}
