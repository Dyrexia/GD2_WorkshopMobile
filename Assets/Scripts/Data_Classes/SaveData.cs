using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveData//classes pour stocker toutes les données du joueur
{
    public List<ZombieData> zombieList;
    public SerializableDictionary<string, ItemListWrapper> ItemLists;
    public List<BarrelData> BarrelList;
    public int InventorySize;
    public int MaxZombies;
    public SaveData() 
    {
        zombieList=new List<ZombieData>();
        ItemLists=new SerializableDictionary<string, ItemListWrapper>();
        ItemLists.Add("Tête",new ItemListWrapper());
        ItemLists.Add("Bras droit", new ItemListWrapper());
        ItemLists.Add("Bras gauche", new ItemListWrapper());
        ItemLists.Add("Torse", new ItemListWrapper());
        ItemLists.Add("Jambe gauche", new ItemListWrapper());
        ItemLists.Add("Jambe droite", new ItemListWrapper());
        BarrelList =new List<BarrelData>();
        InventorySize=10;
        MaxZombies=3;
    }
}
[Serializable]
public class ItemListWrapper
{
    public List<ItemWrapper> Items;
}
[Serializable]
public class ItemWrapper
{
    public ItemData ItemData;
}
