using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveData//classes pour stocker toutes les données du joueur
{
    public List<ZombieData> zombieList;
    public List<ItemData> ItemList;
    public List<BarrelData> BarrelList;
    public int InventorySize;
    public int MaxZombies;
    public SaveData() 
    {
        zombieList=new List<ZombieData>();
        ItemList=new List<ItemData>();
        BarrelList=new List<BarrelData>();
        InventorySize=0;
        MaxZombies=0;
    }
}
