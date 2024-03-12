using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;
using static UnityEditor.Progress;

public class UI_ShowStat : MonoBehaviour
{
   
    public TextMeshProUGUI NomNewItem;
    public ItemData itemData;
    public TextMeshProUGUI Infection;
    public TextMeshProUGUI Intelligence;
    public TextMeshProUGUI Furtivite;
    public TextMeshProUGUI Durabilite;
    public TextMeshProUGUI Puissance;
    public TextMeshProUGUI Niveau;
    public TextMeshProUGUI DescriptionItem;
    public List<GameObject> Sliders = new List<GameObject>();
    public ItemData OldItemRef;
    public string bodypart;
    
   
   
    private int NombreDeBouton;
    public void NewStatsChangement(ItemData Item)
    {
        OldItemRef = MainManager.Instance.PlayerData.zombieList[MainManager.Instance.CurrentZombie].EquippedParts[Item.Bodypart];

        Infection.text = Item.Infection.ToString();
        CompareValues(OldItemRef.Infection, Item.Infection, Sliders[0].GetComponent<UI_ProgressBarStat>());

        Intelligence.text = Item.Intelligence.ToString();
        CompareValues(OldItemRef.Intelligence, Item.Intelligence, Sliders[1].GetComponent<UI_ProgressBarStat>());

        Furtivite.text = Item.Stealth.ToString();
        CompareValues(OldItemRef.Stealth, Item.Stealth, Sliders[2].GetComponent<UI_ProgressBarStat>());

        Durabilite.text = Item.Durability.ToString();
        CompareValues(OldItemRef.Durability, Item.Durability, Sliders[3].GetComponent<UI_ProgressBarStat>());

        Puissance.text = Item.Power.ToString();
        CompareValues(OldItemRef.Power, Item.Power, Sliders[4].GetComponent<UI_ProgressBarStat>());

        Niveau.text = Item.Level.ToString();
        CompareValues(OldItemRef.Level, Item.Level, Sliders[5].GetComponent<UI_ProgressBarStat>());

        NomNewItem.text = Item.Name.ToString();

        DescriptionItem.text = Item.Description;


        float PuissanceNormalize = Mathf.Clamp01(1f-(Mathf.Pow(2.23f, Item.Level)-(float)Item.Power) / Mathf.Pow(2.23f, Item.Level));
       
     }

    private void CompareValues(float OldStat, float NewStat,UI_ProgressBarStat Barre)

    {
        if (OldStat <= NewStat)
        {
            Barre.UpdateNumber(1-Mathf.Clamp01((NewStat - OldStat) / NewStat), Color.green);
            return;
        }
            Barre.UpdateNumber(1-Mathf.Clamp01((OldStat - NewStat) / OldStat), Color.red);
            return;
    }

    
    
    private void Start()
    {
        OldItemRef = MainManager.Instance.PlayerData.zombieList[MainManager.Instance.CurrentZombie].EquippedParts[bodypart];
        NewStatsChangement(OldItemRef);
    }
}
