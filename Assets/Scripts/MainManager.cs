using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.ComponentModel;
using Unity.VisualScripting;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public SaveData PlayerData = new SaveData();


    private void Awake()//On charge l'instance du joueur et ses données
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
    void OnApplicationFocus(bool hasFocus)//on sauvegarde quand le joueur sort de l'application (sur mobile elle est jamais quittée, elle est pausée) et on charge quand il la lance
    {
        if (!hasFocus)
            SaveFunctions.SavePlayerInfos();
        else
            SaveFunctions.LoadPlayerInfos();
    }
}