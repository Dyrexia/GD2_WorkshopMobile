using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Zombie_Away : MonoBehaviour
{
    private ZombieData ActiveZombie;
    //private void Start()
    //{
    //    GameObject.FindGameObjectWithTag("MissionStat").GetComponent<TextMeshProUGUI>().text= "Gnegnegne";//pour changer le texte d'un ui ATTENTION faut mettre le tag sur le texte directement
    //}
    private float NumberOfZombies(float t,float MilStr,int infection=0, int power = 0)
    {
        return Mathf.Floor(Mathf.Sqrt(t) * infection - MilStr / power);
    }
    private float MilitaryStrength(float t,bool HaveArrived,float TimeOfArrival=0) 
    {
        if (HaveArrived)
        {
            return (t - TimeOfArrival) * (t - TimeOfArrival);
        }
        return 0f;
    }
    private void SetActiveZombie(int zombieID)
    {
        ActiveZombie = MainManager.Instance.PlayerData.zombieList[zombieID];
    }
    private void ShowZombieProgression()
    {
        StartCoroutine(UpdateZombieProgression(1));
    }
    private void HideZombieProgression()
    {
        StopCoroutine("UpdateZombieProgression");
    }
    public IEnumerator UpdateZombieProgression(int zombieID)
    {
        double t = (ActiveZombie.GetExpectedReturn()-ActiveZombie.GetDepartureTime()).TotalSeconds;
        if (t < 0f)
        {
            //on fait revenir le zombie ici
        }
        else
        {
            int MissionDuration = 0;
            int TimeOfArrival = 0;
            bool HaveArrived = false;
            while (t < MissionDuration)
            {
                t += 1;
                if (t > TimeOfArrival)
                {
                    HaveArrived = true;
                }
                //Debug.Log("NZombies : " + NumberOfZombies(t, MilitaryStrength(t, HaveArrived)).ToString() + " Time : " + t.ToString());
                yield return new WaitForSeconds(1);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
