using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveFunctions
{
    public static void SavePlayerInfos()//on sauvegarde l'état des zombies et des items
    {
        string json = JsonUtility.ToJson(MainManager.Instance.PlayerData);
        File.WriteAllText(Application.persistentDataPath + "/SaveFile.json", json);
    }
    public static void LoadPlayerInfos()
    {
        if (File.Exists(Application.persistentDataPath + "/SaveFile.json"))
        {
            string json = File.ReadAllText(Application.persistentDataPath + "/SaveFile.json");
            MainManager.Instance.PlayerData = JsonUtility.FromJson<SaveData>(json);
        }
        else
        {
            ResetPlayerData();//si le joueur n'a pas de sauvegarde, on lui en crée une
        }
    }
    public static void ResetPlayerData()
    {
        MainManager.Instance.PlayerData.zombieList.Clear();
        MainManager.Instance.PlayerData.zombieList.Add(new ZombieData());
        MainManager.Instance.PlayerData.ItemLists.Clear();
        MainManager.Instance.PlayerData.ItemLists.Add("Tête", new ItemListWrapper());
        MainManager.Instance.PlayerData.ItemLists.Add("Bras droit", new ItemListWrapper());
        MainManager.Instance.PlayerData.ItemLists.Add("Bras gauche", new ItemListWrapper());
        MainManager.Instance.PlayerData.ItemLists.Add("Torse", new ItemListWrapper());
        MainManager.Instance.PlayerData.ItemLists.Add("Jambe gauche", new ItemListWrapper());
        MainManager.Instance.PlayerData.ItemLists.Add("Jambe droite", new ItemListWrapper());
        MainManager.Instance.PlayerData.MaxZombies = 3;
        MainManager.Instance.PlayerData.InventorySize = 10;
        SavePlayerInfos();
    }
}
