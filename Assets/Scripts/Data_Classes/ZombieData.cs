using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ZombieData//classe pour les données des zombies
{
    public bool IsAway;
    public long ExpectedReturn;
    public ItemData[] EquippedParts;
    public string Name;
    public ZombieData(string name = "John") //on initialise le zombie avec le stuff de base
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
