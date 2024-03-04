using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UI_ItemButton : MonoBehaviour
{
    public ItemData NewItem;
    public Button ButtonItem;
    public UI_ShowStat Ui_ShowStatScript;

    // Start is called before the first frame update
    void Start()
    {
        ItemData NewItem = new ItemData("Tête", Random.Range(0, 4));
        Debug.Log("Infection:" + NewItem.Infection);
        ButtonItem.onClick.AddListener(delegate {Ui_ShowStatScript.NewStatsChangement(NewItem); });

    }
   
    // Update is called once per frame
    void Update()
    {
        
    }

    
}
