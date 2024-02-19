using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.ComponentModel;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    void GetDateTime()
    {
        Debug.Log(DateTime.Now<new DateTime(2024,12,19));
        return;
    }
    ZombieData Adolph= new ZombieData();
    ZombieData Goebels= new ZombieData();
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        Adolph.ExpectedReturn = DateTime.Now;
        LoadData();
        SaveData();
        Debug.Log(Adolph.ExpectedReturn < Goebels.ExpectedReturn);
        Debug.Log((Application.persistentDataPath + "/SaveFile.json"));
    }
    public void SaveData()
    {
        ZombieData Data = MainManager.Instance.Adolph;
        string json = JsonUtility.ToJson(Data);
        File.WriteAllText(Application.persistentDataPath + "/SaveFile.json", json);
    }
    public void LoadData()
    {
        string json = File.ReadAllText(Application.persistentDataPath + "/SaveFile.json");
        MainManager.Instance.Goebels = JsonUtility.FromJson<ZombieData>(json);
        Debug.Log(Goebels.ExpectedReturn.ToString()+"sauvegarde");
    }
    [System.Serializable]
    /*public class SaveData
    {
        public List<ZombieData> zombieList;
        public List<ItemData> ItemList;
    }*/
    public class ZombieData
    {
        public DateTime ExpectedReturn;
    }
    public class ItemData
    {
        public string Name;
    }
}
