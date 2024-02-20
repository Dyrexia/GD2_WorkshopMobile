using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.ComponentModel;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    [Serializable]
    public class SaveData//classes pour stocker toutes les donn�es du joueur
    {
        public List<ZombieData> zombieList = new List<ZombieData>();
        public List<ItemData> ItemList = new List<ItemData>();
    }
    [Serializable]
    public class ZombieData//classe pour les donn�es des zombies
    {
        public bool IsAway;
        public long ExpectedReturn;
    }
    [Serializable]
    public class ItemData//classe pour tout les donn�es des items
    {
        public string Name;
    }
    public SaveData PlayerData = new SaveData();


    private void Awake()//On charge l'instance du joueur et ses donn�es
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        LoadPlayerInfos();
    }

    public void SavePlayerInfos()//on sauvegarde l'�tat des zombies et des items
    {
        string json = JsonUtility.ToJson(PlayerData);
        File.WriteAllText(Application.persistentDataPath + "/SaveFile.json", json);
    }
    public void LoadPlayerInfos()
    {
        string json = File.ReadAllText(Application.persistentDataPath + "/SaveFile.json");
        Instance.PlayerData = JsonUtility.FromJson<SaveData>(json);
    }
    void OnApplicationFocus(bool hasFocus)//on sauvegarde quand le joueur sort de l'application (sur mobile elle est jamais quitt�e, elle est paus�e) et on charge quand il la lance
    {
        if (!hasFocus)
            SavePlayerInfos();
        else
            LoadPlayerInfos();
    }
}
