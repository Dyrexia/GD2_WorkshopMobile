using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ConfirmationDelete : MonoBehaviour
{
    public Button yesButton;
    public Button noButton;
    //public bool IsConfirmed()
    //{ 

    //}

    private void Start()
    {

        yesButton.onClick.AddListener(ok);

    }

    private void ok ()
    {
        Debug.Log("ok");

    }
}


