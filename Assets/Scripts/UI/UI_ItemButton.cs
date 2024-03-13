using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.U2D.Animation;
using UnityEngine.UI;

public class UI_ItemButton : MonoBehaviour
{
    private UI_ShowStat Ui_ShowStatScript;
    private GameObject PanelNewItemRef ;
    [SerializeField]private ItemData ItemRef;
    

    // Start is called before the first frame update


    public void Initialize(ItemData Item)
    {
        ItemRef = Item; //= ItemRef.Name;
            foreach(TextMeshProUGUI txt in GetComponentsInChildren<TextMeshProUGUI>())
        {
            if (txt.name == "NomItemNew")
                txt.SetText(ItemRef.Name);
            else if (txt.name =="StatNiveauItemNew")
                txt.SetText(ItemRef.Level.ToString());
        }
        PanelNewItemRef = GameObject.FindGameObjectWithTag("PanelNewItem");
        Ui_ShowStatScript = PanelNewItemRef.GetComponent<UI_ShowStat>();
        gameObject.GetComponent<Button>().onClick.AddListener(delegate 
        { 
            Ui_ShowStatScript.NewStatsChangement(ItemRef);
            GameObject.FindGameObjectWithTag("InventoryButtons").GetComponent<UI_InventoryButton>().item = Item;
        });
        GetComponentInChildren<Image>().sprite=GetComponentInParent<SpriteLibrary>().GetSprite(Item.Bodypart,Item.SkinLabel);
    }
    private void OnDisable()
    {
        Destroy(gameObject);
    }
}
