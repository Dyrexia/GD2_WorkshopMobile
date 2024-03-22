using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_ImageRecompense : MonoBehaviour
{
    public void Initialize(Sprite sprite, int level)
    
    {
        GetComponentInChildren<Image>().sprite = sprite;
        GetComponentInChildren<TextMeshProUGUI>().text= "level : " + level;
        Debug.Log("Initiliaze");

    }
    
        
    
}

