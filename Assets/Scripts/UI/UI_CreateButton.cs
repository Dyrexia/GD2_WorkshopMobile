using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class UI_CreateButton : MonoBehaviour
{
    public List<ItemWrapper> itemDataRef = new List<ItemWrapper>();
    public Button ButtonBodypart;
    public Transform CanvaButton;
    public UI_ShowStat UI_ShowStatRef;
    // Start is called before the first frame update
    public void CreateButton (string bodypart) 
    {
        //itemDataRef = MainManager.Instance.PlayerData.ItemLists[bodypart].Items.Sort();
        foreach (ItemWrapper item in itemDataRef)
        {
            if (item >)
            {

                
            }
            
            else
            {
                

            }
           
          

            if(item== itemDataRef[itemDataRef.Count - 1])
            {
                Button newButton = Instantiate(ButtonBodypart, CanvaButton);
                newButton.GetComponent<UI_ItemButton>().Initialize(item.ItemData);
                newButton.gameObject.SetActive(true);
            }

           

        }
        //newButton.onClick.AddListener(() => OnButtonClick(bodypart));
    }    
}
