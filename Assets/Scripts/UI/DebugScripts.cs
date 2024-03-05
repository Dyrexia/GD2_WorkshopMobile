using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEditor;
using UnityEngine;

public class DebugScripts : MonoBehaviour
{
    private int TotalInfection;
    private int TotalIntelligence;
    private int TotalPower;
    private int TotalStealth;
    public void newItem()
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
    public void InitCustomSave()
    {
        for (int k = 0; k < 3; k++)
        {
            MainManager.Instance.PlayerData.zombieList[k] = new ZombieData();
            for (int i = 0; i < 6; i++)
            {
                MainManager.Instance.PlayerData.zombieList[k].EquippedParts[i] = new ItemData("Osef", k);
            }
        }
    }

    private void Start()
    {
    }
}
