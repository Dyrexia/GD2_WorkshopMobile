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
    public UI_HideShow EndMissionCanvas;
    public UI_HideShow MainMenu;
    private int t;
    private void OnEnable()
    {
        if (MainManager.Instance != null)
            ShowZombieProgression();
    }
    private void OnDisable()
    {
        HideZombieProgression();
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
        return Mathf.FloorToInt(1+ZombieInfection()-MilitaryStrength());
    }

    private void SetActiveZombie(int zombieID)
    {
        ActiveZombie = MainManager.Instance.PlayerData.zombieList[zombieID];
    }
    public void ShowZombieProgression()
    {
        if (MainManager.Instance.PlayerData.zombieList.Count != 0 && ActiveZombie.IsAway==true)
        {
            StartCoroutine(UpdateZombieProgression(MainManager.Instance.CurrentZombie));
        }
        
        
    }
    private void HideZombieProgression()
    {
        StopCoroutine("UpdateZombieProgression");
        GetComponent<UI_HideShow>().HideCanvas();

    }
    public IEnumerator UpdateZombieProgression(int zombieID)
    {
        SetActiveZombie(zombieID);
        double TotalTime = (ActiveZombie.GetExpectedReturn()-ActiveZombie.GetDepartureTime()).TotalSeconds;
        double RemainingTime = (ActiveZombie.GetExpectedReturn()-DateTime.Now).TotalSeconds;
        Debug.Log(TotalTime);
        Debug.Log(RemainingTime);
        while (RemainingTime > (double)0)
        {
            Debug.Log(RemainingTime);
            t = (int)TotalTime - (int)RemainingTime;
            if (NumberOfZombies() <= 0) 
            {
                MissionStats.text = 0.ToString();
                HideZombieProgression();
                ActiveZombie.IsAway = false;
                break;
            }
            MissionStats.text=NumberOfZombies().ToString();
            Debug.Log(t);
            DurationStats.text=((int)RemainingTime/3600)+"h"+((int)(RemainingTime%3600)/60+"m"+((int)(RemainingTime%60))+"s");
            RemainingTime = (ActiveZombie.GetExpectedReturn() - DateTime.Now).TotalSeconds;
            if (RemainingTime <= 0)
            {
                HideZombieProgression();
                EndMissionCanvas.ShowCanvas();
                MainMenu.HideCanvas();
                ActiveZombie.IsAway = false;//FIN DE PARTIE
            }
            yield return new WaitForSeconds(1);
        }
        HideZombieProgression();
        EndMissionCanvas.ShowCanvas();
        MainMenu.HideCanvas();
        ActiveZombie.IsAway=false;
    }
}
