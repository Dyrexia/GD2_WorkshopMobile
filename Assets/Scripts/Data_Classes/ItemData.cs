using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
/*Classe pour définir les items
 *Pour le constructeur :
 * Power = 2.23^Level (Nb choisi pour être environ égal à 166 500 au niveau 15)
 * 
 * 
 * 
 * 
 * 
 */

[Serializable]
public class ItemData//classe pour tout les données des items
{
    private string[] NameChar = new string[]{ " irregardable"," moche", " passable", " magnifique" }; //lvl0, lvl1, lvl2; lvl3
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
    public ItemData(string bodypart, int level = 0, int skin = 0)//constructeur de la classe : seule la bodypart et le level sont importants, le reste est généré aléatoirement à partir de ces 2 infos
    {
        Bodypart = bodypart;
        Level = level;
        SkinIndex = skin;
        IsInBarrel = false;
        Name = Bodypart + NameChar[level];
        Infection = level / 2 + level % 2;//0 si lvl0, 1 si lvl1 ou 2, 2 si lvl3
        Intelligence = level;
        float templevel = level;
        Power = Mathf.Pow(2.23f, (float)Level);
        Stealth = UnityEngine.Random.Range(level*5,level*17);
        SizeInInventory = level;
    }
    private void GenerateRandomModifier()//On génère 3 nombres aléatoires avec cette équation x²+y²+z²= 1. selon le nb de chiffres négatifs on applique des buffs aux positifs
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

