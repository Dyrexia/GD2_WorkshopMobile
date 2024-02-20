using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class ItemData//classe pour tout les données des items
{
    public string Name;
    public string Description;
    public string Bodypart;
    public bool IsInBarrel;
    public int SkinIndex;
    public int Level;
    public int SizeInInventory;
    public int Infection;
    public int Intelligence;
    public int Power;
    public int Stealth;
    public int Durability;
    public float FermentationModifier;
    public ItemData(string bodypart, int level = 0, int skin = 0)//constructeur de la classe : seule la bodypart et le level sont importants, le reste est généré aléatoirement à partir de ces 2 infos
    {
        Bodypart = bodypart;
        Level = level;
        SkinIndex = skin;
        IsInBarrel = false;
        if (Level == 0)//partie de base nulle
        {
            Name = Bodypart + " irregardable";
            Infection = 0;
            Intelligence = 0;
            Power = 0;
            Stealth = 0;
            Durability = -1;//l'item de base a une DuraInfinie ATTENTION ne doit pas occuper d'espace dans l'inventaire
            FermentationModifier = 0;
            SizeInInventory = 0;
        }
        else//partie lootée avec un niveau il faut ajouter la gen aléatoire
        {
            return;
        }
    }
}
