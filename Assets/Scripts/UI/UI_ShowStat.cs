using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class UI_ShowStat : MonoBehaviour
{
   
    public TextMeshProUGUI NomNewItem;
    public ItemData itemData;
    public TextMeshProUGUI Infection;
    public TextMeshProUGUI Intelligence;
    public TextMeshProUGUI Furtivite;
    public TextMeshProUGUI Durabilite;
    public TextMeshProUGUI Pouvoir;
    public MainManager mainManagerRef;
    private int NombreDeBouton;
   

    // Start is called before the first frame update
    void Start()
    {
     
    }

   
    
   


    // Update is called once per frame
    void Update()
    {
        NomNewItem.text = "Mangervous"; 
    }
    public void NewStatsChangement(ItemData Item)
    {
        Infection.text = Item.Infection.ToString();
        Intelligence.text = Item.Intelligence.ToString();
        Furtivite.text = Item.Stealth.ToString();
        Durabilite.text = Item.Durability.ToString();
        Pouvoir.text = Item.Power.ToString();
 }
    public void CreateButton()
    {

        
    }

}
