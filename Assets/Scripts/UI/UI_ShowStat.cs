using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_ShowStat : MonoBehaviour
{
   
    public TextMeshProUGUI NomNewItem;
    public ItemData itemData;
    

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        NomNewItem.text = "Mangervous"; 
    }
    public void NewStatsChangement()
    {
        

    }

}
