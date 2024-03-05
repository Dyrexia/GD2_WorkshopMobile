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
    public void Start()
    {
        showZombieStat();
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
        foreach (var Item in zombie.EquippedParts)
        {
            power += Item.Value.Power;
            level += Item.Value.Level;
            infection += Item.Value.Infection;
            intelligence += Item.Value.Intelligence;
            stealth += Item.Value.Stealth;
        }
        return "Stats" +
            "\nBeauté : " + level +
            "\nPuissance : " + power +
            "\nInfection : " + infection +
            "\nIntelligence : " + intelligence +
            "\nDiscrétion : " + stealth;
    }
}
