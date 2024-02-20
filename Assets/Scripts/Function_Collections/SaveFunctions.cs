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
        string json = File.ReadAllText(Application.persistentDataPath + "/SaveFile.json");
        MainManager.Instance.PlayerData = JsonUtility.FromJson<SaveData>(json);
    }
}
