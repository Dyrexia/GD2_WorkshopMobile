using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;


[Serializable]
public class ItemData//classe pour tout les donn�es des items
{
    private string[] NameChar = new string[]{ " irregardable"," moche", " passable", " magnifique" }; //lvl0, lvl1, lvl2; lvl3
    private float[,] LevelModifier = new float[,] { { 0, 0 } , {2,7} , {7, 10} , {10,12} };//[level,Stat] 0 = Power, 1 = Infection, 2 = Stealth
    private Vector3 RandomGeneration;
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
    public int FermentationModifier=0;
    public ItemData(string bodypart, int level = 0, int skin = 0)//constructeur de la classe : seule la bodypart et le level sont importants, le reste est g�n�r� al�atoirement � partir de ces 2 infos
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
    private void GenerateRandomModifier()//On g�n�re 3 nombres al�atoires avec cette �quation x�+y�+z�= 1. selon le nb de chiffres n�gatifs on applique des buffs aux positifs
    {
        RandomGeneration = new Vector3();
        RandomGeneration = UnityEngine.Random.onUnitSphere;
        RandomGeneration.z = Mathf.Abs(RandomGeneration.z);
        if (RandomGeneration.x < 0 && RandomGeneration.y<0)
        {
            RandomGeneration.z -= RandomGeneration.x + RandomGeneration.y;
        }
        else if (RandomGeneration.y<0)
        {
            RandomGeneration.x -= RandomGeneration.y / 2;
            RandomGeneration.z -= RandomGeneration.y / 2;
        }
        else if(RandomGeneration.x<0)
        {
            RandomGeneration.y -= RandomGeneration.x / 2;
            RandomGeneration.z -= RandomGeneration.x / 2;
        }
        return;
    }
}

