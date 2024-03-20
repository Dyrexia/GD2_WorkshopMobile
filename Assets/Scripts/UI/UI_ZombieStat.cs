using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_ZombieStat : MonoBehaviour
{
    public TextMeshProUGUI Level;
    public TextMeshProUGUI Infection;
    public TextMeshProUGUI Intelligence;
    public TextMeshProUGUI Power;
    public TextMeshProUGUI Stealth;
    public TextMeshProUGUI Name;
   
    

    public void OnEnable()
    {
        ZombieData zombieRef = MainManager.Instance.PlayerData.zombieList[MainManager.Instance.CurrentZombie];
        Level.text = zombieRef.GetLevel().ToString();
        Infection.text = zombieRef.GetInfection().ToString();
        Intelligence.text = zombieRef.GetInfection().ToString() ;
        Power.text = zombieRef.GetPower().ToString();
        Stealth.text = zombieRef.GetStealth().ToString();
        Name.text = zombieRef.Name;

    }
    
}
