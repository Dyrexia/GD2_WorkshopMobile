using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_ZombieStat : MonoBehaviour
{
    private TextMeshProUGUI Text;
    private void Awake()
    {
        Text = GetComponent<TextMeshProUGUI>();
    }
    public void showZombieStat()
    {
        Text.text = GetZombieStat(MainManager.Instance.PlayerData.zombieList[MainManager.Instance.CurrentZombie]);
    }
    private string GetZombieStat(ZombieData zombie)
    {
        int power = 0;
        int level = 0;
        int infection = 0;
        int intelligence = 0;
        int stealth = 0;
        foreach (ItemData Item in zombie.EquippedParts)
        {
            power += Item.Power;
            level += Item.Level;
            infection += Item.Infection;
            intelligence += Item.Intelligence;
            stealth += Item.Stealth;
        }
        return "Stats" +
            "\nBeauté : " + level +
            "\nPuissance : " + power +
            "\nInfection : " + infection +
            "\nIntelligence : " + intelligence +
            "\nDiscrétion : " + stealth;
    }
}
