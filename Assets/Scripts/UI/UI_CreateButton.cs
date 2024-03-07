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
        foreach (ItemData item in this.itemDataRef)
        {
            Button newButton = Instantiate(ButtonBodypart, CanvaButton);
            newButton.gameObject.SetActive(true);
            Debug.Log("je passe dans la loop");
            newButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = bodypart;
            newButton.GetComponent<UI_ItemButton>();
        }
        //newButton.onClick.AddListener(() => OnButtonClick(bodypart));
    }    
}
