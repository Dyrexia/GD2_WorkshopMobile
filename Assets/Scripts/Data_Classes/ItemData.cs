using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
/*Classe pour définir les items
 *Pour le constructeur :
 * Power = 2.23^Level/2 + ^2.23^Level*(Random.x+biais.x)/2 (Nb choisi pour être environ égal à 166 500 au niveau 15)
 * Infection = 0.13 * Level /2 +0.13*level*(random.z+biais.z)/2 (de même pour 0.13 pour faire 2 au niveau 15)
 * Stealth = 15 * racine5ième(level) + 15*racine5ième(level) * (random.y+Bias.y) (environ 60 au niveau 15) pour éviter avoir un scaling limité à haut niveau mais fort à bas niveau
 * Intelligence 
 * 
 * 
 */

[Serializable]
public class ItemData//classe pour tout les données des items
{
    private string[] NameChar = new string[]{ " irregardable"," moche", " passable", " magnifique" }; //lvl0, lvl1, lvl2; lvl3
    private Vector3 RandomGeneration;
    private Vector3 Bias;
    public string Name;
    public string Description;
    public string Bodypart;
    public bool IsInBarrel;
    public string SkinLabel;
    public int Level;
    public int SizeInInventory;//=level
    public int Infection; //max = 2
    public int Intelligence;
    public int Power;//max = 166 500
    public int Stealth;//max = 60
    public int Durability = 100;
    public int FermentationModifier=0;
    public ItemData(string bodypart, int level = 0, string skin = "Feminin")//constructeur de la classe : seule la bodypart et le level sont importants, le reste est généré aléatoirement à partir de ces 2 infos
    {
        Bodypart = bodypart;
        Level = level;
        SkinLabel = skin;
        IsInBarrel = false;
        Name = Bodypart + NameChar[level/5];
        GenerateRandomModifier();
        Infection = Mathf.CeilToInt((0.13f * level / 2) * (1 + (RandomGeneration.z + Bias.z)));//version factorisé
        Intelligence = level;
        Power = Mathf.FloorToInt((Mathf.Pow(2.23f, level) / 2) * (1 + (RandomGeneration.x + Bias.x)));//version factorisé
        Stealth = Mathf.FloorToInt(15 * Mathf.Pow(level, (1/5)) * (1+(RandomGeneration.y + Bias.y)));//version factorisé
        SizeInInventory = 1;
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
}
class PowerComparer : IComparer<ItemWrapper>
{
    int IComparer<ItemWrapper>.Compare(ItemWrapper x, ItemWrapper y)
    {
        if (x.ItemData.Power > y.ItemData.Power)
            return 1;
        if (x.ItemData.Power < y.ItemData.Power)
            return -1;
        else
            return 0;
    }
}
class StealthComparer : IComparer<ItemWrapper>
{
    int IComparer<ItemWrapper>.Compare(ItemWrapper x, ItemWrapper y)
    {
        if (x.ItemData.Stealth > y.ItemData.Stealth)
            return 1;
        if (x.ItemData.Stealth < y.ItemData.Stealth)
            return -1;
        else
            return 0;
    }
}
class IntelligenceComparer : IComparer<ItemWrapper>
{
    int IComparer<ItemWrapper>.Compare(ItemWrapper x, ItemWrapper y)
    {
        if (x.ItemData.Intelligence > y.ItemData.Intelligence)
            return 1;
        if (x.ItemData.Intelligence < y.ItemData.Intelligence)
            return -1;
        else
            return 0;
    }
}
class InfectionComparer : IComparer<ItemWrapper>
{
    int IComparer<ItemWrapper>.Compare(ItemWrapper x, ItemWrapper y)
    {
        if (x.ItemData.Infection > y.ItemData.Infection)
            return 1;
        if (x.ItemData.Infection < y.ItemData.Infection)
            return -1;
        else
            return 0;
    }
}

