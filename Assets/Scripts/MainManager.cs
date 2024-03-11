using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public List<Sprite> Skins;
    public SaveData PlayerData = new SaveData();
    public int CurrentZombie = 0;


    private void Awake()//On charge l'instance du joueur et ses données
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        SaveFunctions.LoadPlayerInfos();
        //Debug.Log(Application.persistentDataPath + "/SaveFile.json");
        //PlayerData.zombieList[0].EquippedPartsDict.Add("Tête", new ItemData("EZ"));
        //Debug.Log(PlayerData.zombieList[0].EquippedParts["Tête"].Name);
        //Debug.Log((DateTime.Now - DateTime.Now.AddHours(1)).TotalSeconds);
    }
    void OnApplicationFocus(bool hasFocus)//on sauvegarde quand le joueur sort de l'application (sur mobile elle est jamais quittée, elle est pausée) et on charge quand il la lance
    {
        if (!hasFocus)
            SaveFunctions.SavePlayerInfos();
        else
            SaveFunctions.LoadPlayerInfos();
    }
    private void OnApplicationQuit()
    {
        SaveFunctions.SavePlayerInfos();
    }
}