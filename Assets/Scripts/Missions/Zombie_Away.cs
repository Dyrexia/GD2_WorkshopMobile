using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Zombie_Away : MonoBehaviour
{
    private ZombieData ActiveZombie;
    private TextMeshProUGUI MissionStats;
    private int t;
    private void Start()
    {
        MissionStats = GameObject.FindGameObjectWithTag("MissionStat").GetComponent<TextMeshProUGUI>();//pour changer le texte d'un ui ATTENTION faut mettre le tag sur le texte directement
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
        StartCoroutine(UpdateZombieProgression(MainManager.Instance.CurrentZombie));
    }
    private void HideZombieProgression()
    {
        StopCoroutine("UpdateZombieProgression");
    }
    public IEnumerator UpdateZombieProgression(int zombieID)
    {
        SetActiveZombie(zombieID);
        //double TotalTime = (ActiveZombie.GetExpectedReturn()-ActiveZombie.GetDepartureTime()).TotalSeconds;
        //double RemainingTime = (ActiveZombie.GetExpectedReturn()-DateTime.Now).TotalSeconds;
        double TotalTime = 30;
        double RemainingTime = 30;
        while (RemainingTime > 0)
        {
            t = (int)TotalTime - (int)RemainingTime;
            MissionStats.text=NumberOfZombies().ToString();
            //RemainingTime = (ActiveZombie.GetExpectedReturn() - DateTime.Now).TotalSeconds;
            RemainingTime--;
            yield return new WaitForSeconds(1);
        }
    }
}
