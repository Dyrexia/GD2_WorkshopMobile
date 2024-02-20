using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.RestService;
using UnityEngine;

public class Zombie_Send : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {  
    }
    public void SendZombie(int  zombieID, double hours)//permet d'envoyer le zombie à la place "zombieID" de la liste pendant "hours" heures
    {
        if (MainManager.Instance.PlayerData.zombieList[zombieID].IsAway == false)
        {
            MainManager.Instance.PlayerData.zombieList[zombieID].ExpectedReturn = DateTime.Now.AddHours(hours).ToBinary();
            MainManager.Instance.PlayerData.zombieList[zombieID].IsAway = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
