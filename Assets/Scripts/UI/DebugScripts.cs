using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class DebugScripts : MonoBehaviour
{
    private List<string> ItemKeys = new List<string>() { "Tête","Bras droit","Bras gauche","Torse","Jambe gauche","Jambe droite" };
    private int TotalInfection;
    private int TotalIntelligence;
    private int TotalPower;
    private int TotalStealth;
    public void RandomStats()
    {
        TotalInfection=0; TotalIntelligence=0; TotalPower=0; TotalStealth=0;
        for(int i = 0; i<6;i++)
        {
            ItemData a = new ItemData("Tête", Random.Range(3, 4));
            Debug.Log("Name : " + a.Name);
            Debug.Log("Bodypart : " + a.Bodypart);
            Debug.Log("Level : " + a.Level);
            Debug.Log("Infection : " + a.Infection);
            Debug.Log("Intelligence : " + a.Intelligence);
            Debug.Log("Power : " + a.Power);
            Debug.Log("Stealth : " + a.Stealth);
            TotalInfection += a.Infection;
            TotalIntelligence += a.Intelligence;
            TotalPower += a.Power;
            TotalStealth += a.Stealth;
        }
        Debug.Log("TotalInfection = " + TotalInfection);
        Debug.Log("TotalIntelligence = " + TotalIntelligence);
        Debug.Log("TotalPower = " + TotalPower);
        Debug.Log("TotalStealth = " + TotalStealth);
    }
    public void AddRandomItemToList()
    {
        MainManager.Instance.PlayerData.ItemLists["Tête"].Items.Add(new ItemWrapper());
    }
    public void InitCustomSave()
    {
        //for (int k = 0; k < MainManager.Instance.PlayerData.MaxZombies; k++)
        //{
        //    MainManager.Instance.PlayerData.zombieList.Clear();
        //    if (MainManager.Instance.PlayerData.zombieList.Count >= k + 1)
        //        MainManager.Instance.PlayerData.zombieList[k] = new ZombieData();
        //    else
        //        MainManager.Instance.PlayerData.zombieList.Add(new ZombieData());
        //    foreach (string key in ItemKeys)
        //    {
        //        MainManager.Instance.PlayerData.zombieList[k].EquippedParts[key] = new ItemData(key, Random.Range(1, 4));
        //    }
        //}
        MainManager.Instance.PlayerData.zombieList.Clear();
        MainManager.Instance.PlayerData.zombieList.Add(new ZombieData());
        foreach (string key in ItemKeys)
        {
            MainManager.Instance.PlayerData.ItemLists[key].Items.Clear();
            Debug.Log(key);
            for (int k = 0; k<MainManager.Instance.PlayerData.InventorySize; k++)
            {
                MainManager.Instance.PlayerData.ItemLists[key].Items.Add(new ItemWrapper());
                MainManager.Instance.PlayerData.ItemLists[key].Items[k].ItemData=(new ItemData(key, Random.Range(1,16)));
            }
            Debug.Log(MainManager.Instance.PlayerData.ItemLists[key].Items.Count);
        }
    }
    public void DeleteSave()
    {
        SaveFunctions.ResetPlayerData();
    }

    private void Start()
    {
    }
}
