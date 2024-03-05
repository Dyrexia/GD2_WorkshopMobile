using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_CreateButton : MonoBehaviour
{
    public List<ItemData> itemDataRef = new List<ItemData>();
    public Button ButtonBodypart;
    public UI_ShowStat UI_ShowStatRef;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    
    
    public void CreateButton (string bodypart) 
    {
        foreach(ItemData item in MainManager.Instance.PlayerData.ItemList)
        {
            if (item.Bodypart == bodypart)
                itemDataRef.Add(item);
        }
       foreach(ItemData item in this .itemDataRef)
            Debug.Log (item.Bodypart);
    }
        
    
}
