using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class UI_ShowStat : MonoBehaviour
{
   
    public TextMeshProUGUI NomNewItem;
    public ItemData itemData;
    public TextMeshProUGUI Infection;
    public TextMeshProUGUI Intelligence;
    public TextMeshProUGUI Furtivite;
    public TextMeshProUGUI Durabilite;
    public TextMeshProUGUI Pouvoir;
    public TextMeshProUGUI Niveau;
    public TextMeshProUGUI DescriptionItem;
    public MainManager mainManagerRef;
    public Image ImageItem;
    private int NombreDeBouton;
   

    // Start is called before the first frame update
    void Start()
    {
     
    }

   
    
   


    // Update is called once per frame
    void Update()
    {
    }
    public void NewStatsChangement(ItemData Item)
    {
        Infection.text = Item.Infection.ToString();
        Intelligence.text = Item.Intelligence.ToString();
        Furtivite.text = Item.Stealth.ToString();
        Durabilite.text = Item.Durability.ToString();
        Pouvoir.text = Item.Power.ToString();
        Niveau.text = Item.Level.ToString();
        DescriptionItem.text = Item.Description;
       // ImageItem.image mettre image ici? 

 }
    
    
}
