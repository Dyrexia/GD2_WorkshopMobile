using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_InventoryButton : MonoBehaviour
{
    public ItemData item;
    private ItemWrapper TempItem;
    private GameObject PanelNewItemRef;
    private UI_ShowStat Ui_ShowStatScript;
    [SerializeField] private GameObject ConfirmationWindow;
    [SerializeField] private GameObject Frigo;

        private void Start()
    {   
        PanelNewItemRef = GameObject.FindGameObjectWithTag("PanelNewItem");
        Ui_ShowStatScript = PanelNewItemRef.GetComponent<UI_ShowStat>();
       
    }
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
            Ui_ShowStatScript.NewStatsChangement(item);
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
            Ui_ShowStatScript.NewStatsChangement(item);
            return;
        }
        
    }

    public void OpenConfirmationWindow()
    {
        ConfirmationWindow.gameObject.SetActive(true);
        ConfirmationWindow.GetComponentInChildren<UI_ConfirmationDelete>().yesButton.onClick.AddListener(DeleteItem);
        ConfirmationWindow.GetComponentInChildren<UI_ConfirmationDelete>().noButton.onClick.AddListener(cancelDelete);
    }

    //IEnumerator WaitConfirmation ()
    //{


    //    yield return ConfirmationWindow.GetComponent<UI_ConfirmationDelete>().IsConfirmed();
        
    

    //}





    private void cancelDelete()
    {
        ConfirmationWindow.GetComponentInChildren<UI_ConfirmationDelete>().yesButton.onClick.RemoveAllListeners();
        ConfirmationWindow.GetComponentInChildren<UI_ConfirmationDelete>().noButton.onClick.RemoveAllListeners();
        ConfirmationWindow.gameObject.SetActive(false);

    }

    public void DeleteItem()//ajouter la fenêtre de confirmation
    {

        TempItem = new ItemWrapper();
        TempItem.ItemData = MainManager.Instance.PlayerData.zombieList[MainManager.Instance.CurrentZombie].EquippedParts[item.Bodypart];
        Ui_ShowStatScript.NewStatsChangement(TempItem.ItemData);
        
        for (int i = 0; i < MainManager.Instance.PlayerData.ItemLists[item.Bodypart].Items.Count; i++)
        {
            if (MainManager.Instance.PlayerData.ItemLists[item.Bodypart].Items[i].ItemData == item)
                MainManager.Instance.PlayerData.ItemLists[item.Bodypart].Items.Remove(MainManager.Instance.PlayerData.ItemLists[item.Bodypart].Items[i]);
        }
        Frigo.GetComponent<UI_CreateButton>().DestroyButton();
        Frigo.GetComponent<UI_CreateButton>().CreateButton(TempItem.ItemData.Bodypart);
        cancelDelete();
    }
}
