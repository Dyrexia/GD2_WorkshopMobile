using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Send : MonoBehaviour
{
    public void SendZombie(int  zombieID, double hours)//permet d'envoyer le zombie à la place "zombieID" de la liste pendant "hours" heures
    {
        if (MainManager.Instance.PlayerData.zombieList[zombieID].IsAway == false)
        {
            MainManager.Instance.PlayerData.zombieList[zombieID].ExpectedReturn = DateTime.Now.AddHours(hours).ToBinary();
            MainManager.Instance.PlayerData.zombieList[zombieID].DepartureTime = DateTime.Now.ToBinary();
            MainManager.Instance.PlayerData.zombieList[zombieID].IsAway = true;
        }
    }

}
