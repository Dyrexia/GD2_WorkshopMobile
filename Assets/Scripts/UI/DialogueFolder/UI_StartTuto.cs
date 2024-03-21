using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_StartTuto : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       FindObjectOfType<UI_TriggerDialogue>().TriggerDialogue();
    }

}

    
