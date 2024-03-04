using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[Serializable]
public class ItemData//classe pour tout les données des items
{
    private string[] NameChar = new string[]{ " irregardable"," moche", " passable", " magnifique" }; //lvl0, lvl1, lvl2; lvl3
    private float[,] PowerLevelModifier = new float[,] { {0,0} , {2,7} , {7, 10} , {10,12} };
    public string Name;
    public string Description;
    public string Bodypart;
    public bool IsInBarrel;
    public int SkinIndex;//=level
    public int Level;
    public int SizeInInventory;//=level
    public int Infection; //max = 2
    public int Intelligence;
    public int Power;//max = 166 500
    public int Stealth;//max = 50
    public int Durability = 100;
    public float FermentationModifier=0;
    public ItemData(string bodypart, int level = 0, int skin = 0)//constructeur de la classe : seule la bodypart et le level sont importants, le reste est généré aléatoirement à partir de ces 2 infos
    {
        Bodypart = bodypart;
        Level = level;
        SkinIndex = skin;
        IsInBarrel = false;
        Name = Bodypart + NameChar[level];
        Infection = level / 2 + level % 2;//0 si lvl0, 1 si lvl1 ou 2, 2 si lvl3
        Intelligence = level;
        Power =(int)Mathf.Floor(Mathf.Exp(UnityEngine.Random.Range(PowerLevelModifier[level, 0], PowerLevelModifier[level, 1])));//on utilise les bonre du tableau qu'on passe dans l'exponentielle
        Stealth = UnityEngine.Random.Range(level*5,level*17);
        SizeInInventory = level;
    }
}
