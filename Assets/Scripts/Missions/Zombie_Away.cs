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
    private void Start()
    {
        MissionStats = GameObject.FindGameObjectWithTag("MissionStat").GetComponent<TextMeshProUGUI>();//pour changer le texte d'un ui ATTENTION faut mettre le tag sur le texte directement
        ShowZombieProgression();
    }
    private int NumberOfZombies(int t)
    {
        return Mathf.FloorToInt(15*Mathf.Sqrt(t)-Mathf.Pow(t,2)/10);
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
            MissionStats.text=NumberOfZombies((int)TotalTime-(int)RemainingTime).ToString();
            //RemainingTime = (ActiveZombie.GetExpectedReturn() - DateTime.Now).TotalSeconds;
            RemainingTime--;
            yield return new WaitForSeconds(1);
        }
        Debug.Log("ZombieHasReturned");
    }
}
