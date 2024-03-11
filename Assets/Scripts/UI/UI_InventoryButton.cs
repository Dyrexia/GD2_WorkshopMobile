using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_InventoryButton : MonoBehaviour
{
    public ItemData item;
    private ItemWrapper TempItem;
    public void EquipItem()
    {
        TempItem = new ItemWrapper();
        TempItem.ItemData = MainManager.Instance.PlayerData.zombieList[MainManager.Instance.CurrentZombie].EquippedParts[item.Bodypart];
        if (TempItem.ItemData.Level == 0)
        {
            MainManager.Instance.PlayerData.zombieList[MainManager.Instance.CurrentZombie].EquippedParts[item.Bodypart] = item;
            for (int i = 0; i < MainManager.Instance.PlayerData.ItemLists[item.Bodypart].Items.Count; i++)
            {
                if (MainManager.Instance.PlayerData.ItemLists[item.Bodypart].Items[i].ItemData == item)
                    MainManager.Instance.PlayerData.ItemLists[item.Bodypart].Items.Remove(MainManager.Instance.PlayerData.ItemLists[item.Bodypart].Items[i]);
            }
            return;
        }
        else
        {
            MainManager.Instance.PlayerData.zombieList[MainManager.Instance.CurrentZombie].EquippedParts[item.Bodypart] = item;
            for (int i = 0; i < MainManager.Instance.PlayerData.ItemLists[item.Bodypart].Items.Count; i++)
            {
                if (MainManager.Instance.PlayerData.ItemLists[item.Bodypart].Items[i].ItemData==item)
                    MainManager.Instance.PlayerData.ItemLists[item.Bodypart].Items.Remove(MainManager.Instance.PlayerData.ItemLists[item.Bodypart].Items[i]);
            }
            MainManager.Instance.PlayerData.ItemLists[item.Bodypart].Items.Add(TempItem);
            return;
        }
        
    }
}
