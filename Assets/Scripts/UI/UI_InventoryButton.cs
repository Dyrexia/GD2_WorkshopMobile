using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_InventoryButton : MonoBehaviour
{
    public ItemData item;
    private ItemWrapper TempItem;
    public void EquipItem()
    {
        TempItem.ItemData = MainManager.Instance.PlayerData.zombieList[MainManager.Instance.CurrentZombie].EquippedParts[item.Bodypart];
        MainManager.Instance.PlayerData.ItemLists[item.Bodypart].Items.Add(TempItem);
        MainManager.Instance.PlayerData.zombieList[MainManager.Instance.CurrentZombie].EquippedParts[item.Bodypart]=item;
    }
}
