using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class UI_CreateButton : MonoBehaviour
{
    public List<ItemData> itemDataRef = new List<ItemData>();
    public Button ButtonBodypart;
    public Transform CanvaButton;
    public UI_ShowStat UI_ShowStatRef;
    // Start is called before the first frame update
    public void CreateButton (string bodypart) 
    {
        itemDataRef = MainManager.Instance.PlayerData.ItemLists[bodypart];
        foreach (ItemData item in itemDataRef)
        {
            Button newButton = Instantiate(ButtonBodypart, CanvaButton);
            Debug.Log("je passe dans la loop");  
            newButton.GetComponent<UI_ItemButton>().Initialize(item);
            newButton.gameObject.SetActive(true);
        }
        //newButton.onClick.AddListener(() => OnButtonClick(bodypart));
    }    
}
