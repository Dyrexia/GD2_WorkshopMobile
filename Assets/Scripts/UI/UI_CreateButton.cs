using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_CreateButton : MonoBehaviour
{
    private List<ItemData> itemData = new List<ItemData>();
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
                itemData.Add(item);
        }
       
    }
        
    
}
