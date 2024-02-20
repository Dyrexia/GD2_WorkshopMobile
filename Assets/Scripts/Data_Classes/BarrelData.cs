using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BarrelData
{
    public float AlcoholStrength;
    public float Amount;
    public int Level;
    public string Type;
    public ItemData ItemInside;
    public BarrelData()//Constructeur
    {

    }
}
