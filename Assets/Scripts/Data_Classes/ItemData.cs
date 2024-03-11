using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
/*Classe pour d�finir les items
 *Pour le constructeur :
 * Power = 2.23^Level/2 + ^2.23^Level*(Random.x+biais.x)/2 (Nb choisi pour �tre environ �gal � 166 500 au niveau 15)
 * Infection = 0.13 * Level /2 +0.13*level*(random.z+biais.z)/2 (de m�me pour 0.13 pour faire 2 au niveau 15)
 * Stealth = 15 * racine5i�me(level) + 15*racine5i�me(level) * (random.y+Bias.y) (environ 60 au niveau 15) pour �viter avoir un scaling limit� � haut niveau mais fort � bas niveau
 * Intelligence 
 * 
 * 
 */

[Serializable]
public class ItemData//classe pour tout les donn�es des items
{
    private string[] NameChar = new string[]{ " irregardable"," moche", " passable", " magnifique" }; //lvl0, lvl1, lvl2; lvl3
    private Vector3 RandomGeneration;
    private Vector3 Bias;
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
    public int Stealth;//max = 60
    public int Durability = 100;
    public int FermentationModifier=0;
    public ItemData(string bodypart, int level = 0, int skin = 0)//constructeur de la classe : seule la bodypart et le level sont importants, le reste est g�n�r� al�atoirement � partir de ces 2 infos
    {
        Bodypart = bodypart;
        Level = level;
        SkinIndex = skin;
        IsInBarrel = false;
        Name = Bodypart + NameChar[level/5];
        GenerateRandomModifier();
        Infection = Mathf.CeilToInt((0.13f * level / 2) * (1 + (RandomGeneration.z + Bias.z)));//version factoris�
        Intelligence = level;
        Power = Mathf.FloorToInt((Mathf.Pow(2.23f, level) / 2) * (1 + (RandomGeneration.x + Bias.x)));//version factoris�
        Stealth = Mathf.FloorToInt(15 * Mathf.Pow(level, (1/5)) * (1+(RandomGeneration.y + Bias.y)));//version factoris�
        SizeInInventory = 1;
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

class  LevelComparer : IComparer<ItemWrapper>
{
    int IComparer<ItemWrapper>.Compare(ItemWrapper x, ItemWrapper y)
    {
        if (x.ItemData.Level > y.ItemData.Level)
            return 1;
        if (x.ItemData.Level < y.ItemData.Level)
            return -1;
        else
            return 0;
    }
    //public int GetHashCode(ItemWrapper obj)
    //{
    //    return obj.ItemData.Level.GetHashCode();
    //}
}
