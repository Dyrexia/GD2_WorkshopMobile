using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UI_ItemButton : MonoBehaviour
{
    private UI_ShowStat Ui_ShowStatScript;
    private GameObject PanelNewItemRef ;
    [SerializeField]private ItemData ItemRef;
    

    // Start is called before the first frame update


    public void Initialize(ItemData Item)
    {
        ItemRef = Item;
        GetComponentInChildren<TextMeshProUGUI>().text = ItemRef.Name;
        PanelNewItemRef = GameObject.FindGameObjectWithTag("PanelNewItem");
        Ui_ShowStatScript = PanelNewItemRef.GetComponent<UI_ShowStat>();
        //gameObject.GetComponent<Button>().onClick.AddListener(delegate { Ui_ShowStatScript.NewStatsChangement(ItemRef); });
        Debug.Log("Start de l'instanciation");
    }
}
