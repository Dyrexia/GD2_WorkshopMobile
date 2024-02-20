using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.ComponentModel;
using System.IO;
using Unity.VisualScripting;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    [Serializable]
    public class SaveData//classes pour stocker toutes les données du joueur
    {
        public List<ZombieData> zombieList = new List<ZombieData>();
        public List<ItemData> ItemList = new List<ItemData>();
        public List<Barrel> BarrelList = new List<Barrel>();
        public int InventorySize;
        public int MaxZombies;
    }
    [Serializable]
    public class ZombieData//classe pour les données des zombies
    {
        public bool IsAway;
        public long ExpectedReturn;
        public ItemData[] EquippedParts;
        public string Name;
        public ZombieData(string name="John") //on initialise le zombie avec le stuff de base
        { 
            Name = name;
            IsAway = false;
            EquippedParts[0] = new ItemData("Tête");
            EquippedParts[1] = new ItemData("Bras gauche");
            EquippedParts[2] = new ItemData("Bras droit");
            EquippedParts[3] = new ItemData("Torse");
            EquippedParts[4] = new ItemData("Jambe gauche");
            EquippedParts[5] = new ItemData("Jambe droite");
        }
    }
    [Serializable]
    public class ItemData//classe pour tout les données des items
    {
        public string Name;
        public string Description;
        public string Bodypart;
        public bool IsInBarrel;
        public int SkinIndex;
        public int Level;
        public int SizeInInventory;
        public int Infection;
        public int Intelligence;
        public int Power;
        public int Stealth;
        public int Durability;
        public float FermentationModifier;
        public ItemData(string bodypart,int level=0,int skin=0)//constructeur de la classe : seule la bodypart et le level sont importants, le reste est généré aléatoirement à partir de ces 2 infos
        {
            Bodypart = bodypart;
            Level=level;
            SkinIndex=skin;
            IsInBarrel = false;
            if (Level == 0)//partie de base nulle
            {
                Name = Bodypart + " irregardable";
                Infection = 0;
                Intelligence = 0;
                Power = 0;
                Stealth = 0;
                Durability = -1;//l'item de base a une DuraInfinie ATTENTION ne doit pas occuper d'espace dans l'inventaire
                FermentationModifier = 0;
                SizeInInventory = 0;
            }
            else//partie lootée avec un niveau il faut ajouter la gen aléatoire
            {
                return;
            }
        }
    }
    [Serializable]
    public class Barrel
    {
        public float AlcoholStrength;
        public float Amount;
        public int Level;
        public string Type;
        public ItemData ItemInside;
    }
    public SaveData PlayerData = new SaveData();


    private void Awake()//On charge l'instance du joueur et ses données
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        LoadPlayerInfos();
    }

    public void SavePlayerInfos()//on sauvegarde l'état des zombies et des items
    {
        string json = JsonUtility.ToJson(PlayerData);
        File.WriteAllText(Application.persistentDataPath + "/SaveFile.json", json);
    }
    public void LoadPlayerInfos()
    {
        string json = File.ReadAllText(Application.persistentDataPath + "/SaveFile.json");
        Instance.PlayerData = JsonUtility.FromJson<SaveData>(json);
    }
    void OnApplicationFocus(bool hasFocus)//on sauvegarde quand le joueur sort de l'application (sur mobile elle est jamais quittée, elle est pausée) et on charge quand il la lance
    {
        if (!hasFocus)
            SavePlayerInfos();
        else
            LoadPlayerInfos();
    }
}