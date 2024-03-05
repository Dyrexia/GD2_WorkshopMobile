using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveData//classes pour stocker toutes les données du joueur
{
    public List<ZombieData> zombieList;
    public SerializableDictionary<string, List<ItemData>> ItemLists;
    public List<BarrelData> BarrelList;
    public int InventorySize;
    public int MaxZombies;
    public SaveData() 
    {
        zombieList=new List<ZombieData>();
        ItemLists=new SerializableDictionary<string, List<ItemData>>();
        ItemLists.Add("Tête",new List<ItemData>());
        ItemLists.Add("Bras droit", new List<ItemData>());
        ItemLists.Add("Bras gauche", new List<ItemData>());
        ItemLists.Add("Torse", new List<ItemData>());
        ItemLists.Add("Jambe gauche", new List<ItemData>());
        ItemLists.Add("Jambe droite", new List<ItemData>());
        BarrelList =new List<BarrelData>();
        InventorySize=10;
        MaxZombies=3;
    }
}
