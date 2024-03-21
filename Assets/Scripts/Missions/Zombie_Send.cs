using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Zombie_Send : MonoBehaviour
{
    public GameObject MissionDescription;
    public Zombie_Send PlayButton;
    public Zombie_Send Mission;
    private double hours = 0;
    private float difficulty = 0;
    public int LevelClass = 0;
    private void OnEnable()
    {
        difficulty=UnityEngine.Random.value*3+LevelClass*3;
        hours = UnityEngine.Random.value*3+LevelClass*3+1;
        if (LevelClass == 0)
            hours = 1f / 60f;
        if (MissionDescription != null)
        foreach (var text in MissionDescription.GetComponentsInChildren<TextMeshProUGUI>())
        {
            if (text.name == "StatDifficulte")
                text.text = (Mathf.Floor(difficulty*10)/10).ToString();
            if (text.name == "StatDuree")
                text.text = Mathf.Floor((float)hours).ToString() + "h" + Mathf.Floor(((float)hours- Mathf.Floor((float)hours)) * 60).ToString()+'m';
        }
    }
    public void SetMission() 
    {
        PlayButton.Mission=gameObject.GetComponent<Zombie_Send>();
    }
    public void SendZombie()//permet d'envoyer le zombie à la place "zombieID" de la liste pendant "hours" heures
    {
        if (MainManager.Instance.PlayerData.zombieList[MainManager.Instance.CurrentZombie].IsAway == false)
        {
            Debug.Log("gesd");
            MainManager.Instance.PlayerData.zombieList[MainManager.Instance.CurrentZombie].ExpectedReturn = DateTime.Now.AddHours(Mission.hours).ToBinary();
            MainManager.Instance.PlayerData.zombieList[MainManager.Instance.CurrentZombie].DepartureTime = DateTime.Now.ToBinary();
            MainManager.Instance.PlayerData.zombieList[MainManager.Instance.CurrentZombie].IsAway = true;
            MainManager.Instance.PlayerData.zombieList[MainManager.Instance.CurrentZombie].MissionDifficulty = Mission.difficulty;
        }
    }

}
