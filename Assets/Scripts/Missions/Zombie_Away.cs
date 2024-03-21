using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Zombie_Away : MonoBehaviour
{
    private ZombieData ActiveZombie;
    public TextMeshProUGUI MissionStats;
    public TextMeshProUGUI DurationStats;
    private int t;
    private void OnEnable()
    {
        ShowZombieProgression();
    }
    private float MilitaryStrength()
    {
        if (t < ActiveZombie.GetStealth())
        {
            return 0;
        }
        return Mathf.Pow(t-ActiveZombie.GetStealth(), 2+ActiveZombie.MissionDifficulty)/ActiveZombie.GetPower();
    }
    private float ZombieInfection()
    {
        return ActiveZombie.GetInfection() * Mathf.Sqrt(t);
    }
    private int NumberOfZombies()
    {
        return Mathf.FloorToInt(ZombieInfection()-MilitaryStrength());
    }

    private void SetActiveZombie(int zombieID)
    {
        ActiveZombie = MainManager.Instance.PlayerData.zombieList[zombieID];
    }
    public void ShowZombieProgression()
    {
        if (MainManager.Instance != null)
        StartCoroutine(UpdateZombieProgression(MainManager.Instance.CurrentZombie));
        Debug.Log("Gnegnegne");
    }
    private void HideZombieProgression()
    {
        StopCoroutine("UpdateZombieProgression");
        ActiveZombie.IsAway = false;
    }
    public IEnumerator UpdateZombieProgression(int zombieID)
    {
        SetActiveZombie(zombieID);
        double TotalTime = (ActiveZombie.GetExpectedReturn()-ActiveZombie.GetDepartureTime()).TotalSeconds;
        double RemainingTime = (ActiveZombie.GetExpectedReturn()-DateTime.Now).TotalSeconds;
        while (RemainingTime > 0)
        {
            t = (int)TotalTime - (int)RemainingTime;
            if (NumberOfZombies() <= 0) 
            {
                MissionStats.text = 0.ToString();
                HideZombieProgression();
                break;
            }
            MissionStats.text=NumberOfZombies().ToString();
            Debug.Log("kasKouil");
            DurationStats.text=((int)RemainingTime/3600)+"h"+((int)(RemainingTime%3600)/60+"m"+((int)(RemainingTime%60))+"s");
            RemainingTime = (ActiveZombie.GetExpectedReturn() - DateTime.Now).TotalSeconds;
            yield return new WaitForSeconds(1);
        }
        HideZombieProgression();//FIN DE PARTIE
    }
}
