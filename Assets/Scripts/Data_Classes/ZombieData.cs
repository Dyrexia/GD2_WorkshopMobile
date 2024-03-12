using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class ZombieData//classe pour les données des zombies
{
    public bool IsAway;
    public long ExpectedReturn;
    public long DepartureTime;
    public SerializableDictionary<string, ItemData> EquippedParts = new SerializableDictionary<string, ItemData>();

    public string Name;
    public ZombieData(string name = "John") //on initialise le zombie avec le stuff de base
    {
        Name = name;
        IsAway = false;
        EquippedParts.Add("Tête",new ItemData("Tête"));
        EquippedParts.Add("Bras gauche", new ItemData("Bras gauche")); 
        EquippedParts.Add("Bras droit", new ItemData("Bras droit"));
        EquippedParts.Add("Torse", new ItemData("Torse"));
        EquippedParts.Add("Jambe gauche", new ItemData("Jambe gauche"));
        EquippedParts.Add("Jambe droite", new ItemData("Jambe droite"));
    }
    public DateTime GetExpectedReturn()
    {
        return DateTime.FromBinary(ExpectedReturn);
    }
    public DateTime GetDepartureTime() 
    {
        return DateTime.FromBinary(DepartureTime);
    }
}
