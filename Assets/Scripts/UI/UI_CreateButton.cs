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
    public float CountTest = 0;
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
      
       
        if (MainManager.Instance != null && MainManager.Instance.PlayerData != null && MainManager.Instance.PlayerData.ItemLists != null)

            itemDataRef = MainManager.Instance.PlayerData.ItemLists[bodypart];
        foreach (ItemData item in this.itemDataRef)
        {
            Debug.Log(item.Bodypart);
            CountTest++;
            Debug.Log(CountTest);
            Button newButton = Instantiate(ButtonBodypart, CanvaButton);
            newButton.transform.position = new Vector3(CanvaButton.position.x+20000, CanvaButton.position.y+3, CanvaButton.position.z+4);
           
          
          
            newButton.gameObject.SetActive(true);
            newButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = bodypart;
            
        }
        //newButton.onClick.AddListener(() => OnButtonClick(bodypart));
    }
        
    
}
