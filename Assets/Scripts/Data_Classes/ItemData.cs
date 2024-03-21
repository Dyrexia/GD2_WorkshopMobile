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
    public string SkinLabel;
    public int Level;
    public int SizeInInventory;//=level
    public int Infection; //max = 2
    public int Intelligence;
    public int Power;//max = 166 500
    public int Stealth;//max = 60
    public int Durability = 100;
    public int FermentationModifier=0;
    public ItemData(string bodypart, int level = 0)//constructeur de la classe : seule la bodypart et le level sont importants, le reste est g�n�r� al�atoirement � partir de ces 2 infos
    {
        Bodypart = bodypart;
        Level = level;
        SkinLabel = GetSkin(level);
        Description = DescriptionHolder.GetDescription(Bodypart, SkinLabel);
        IsInBarrel = false;
        Name = Bodypart + NameChar[level/5];
        GenerateRandomModifier();
        Infection = Mathf.CeilToInt((0.13f * level / 2) * (1 + (RandomGeneration.z + Bias.z)));//version factoris�
        Intelligence = level;
        Power = Mathf.FloorToInt((Mathf.Pow(2.23f, level) / 2) * (1 + (RandomGeneration.x + Bias.x)));//version factoris�
        Stealth = Mathf.FloorToInt(15 * Mathf.Pow(level, (1/5)) * (1+(RandomGeneration.y + Bias.y)));//version factoris�
        SizeInInventory = 1;
    }
    private string GetSkin(int level)
    {
        string[] SkinList = {"Basique","Feminin","Gangster","Rastafara","PopStar" };
        if(level == 0) 
            return "Basique";
        if (level < 5)
            return SkinList[UnityEngine.Random.Range(0, 2)];
        if (level < 10)
            return SkinList[UnityEngine.Random.Range(1, 3)];
        return SkinList[UnityEngine.Random.Range(2, 4)];
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
public static class DescriptionHolder
{
    public static string GetDescription(string part,string skin)
    {
        switch (skin) 
        {
            case "Basique":
                switch (part)
                {
                    case "T�te":
                        return "Cette t�te zombie, d�nu�e de toute intelligence, est le joyau de la couronne des horreurs, le parfait accessoire pour les zombies qui veulent se d�marquer dans le monde grotesque des non-morts.";
                    case "Torse":
                        return "Ce torse zombie, d�pourvu de tout six-pack, est la quintessence de la mode d�braill�e, le v�tement id�al pour ceux qui veulent faire sensation dans le monde des morts-vivants.";
                    case "Bras droit":
                        return "Avec ses ongles �caill�s et sa peau d�color�e, il semble avoir �t� emprunt� � une vieille marionnette oubli�e dans un placard poussi�reux. Ce bras zombie, d�pourvu de toute gr�ce, est le parfait accessoire pour les zombies qui cherchent � impressionner avec leur style d�braill� et leur d�sir insatiable de chair fra�che.\r\n";
                    case "Bras gauche":
                        return "Avec ses ongles �caill�s et sa peau d�color�e, il semble avoir �t� emprunt� � une vieille marionnette oubli�e dans un placard poussi�reux. Ce bras zombie, d�pourvu de toute gr�ce, est le parfait accessoire pour les zombies qui cherchent � impressionner avec leur style d�braill� et leur d�sir insatiable de chair fra�che.\r\n";
                    case "Jambe droite":
                        return "Cette jambe zombie, aux articulations d�sarticul�es, est le parfait accessoire pour les zombies qui veulent donner l'impression d'avoir toujours un pied dans la tombe, litt�ralement.";
                    case "Jambe gauche":
                        return "Cette jambe zombie, aux articulations d�sarticul�es, est le parfait accessoire pour les zombies qui veulent donner l'impression d'avoir toujours un pied dans la tombe, litt�ralement.";
                }
                break;
            case "Feminin":
                switch (part)
                {
                    case "T�te":
                        return "D�pourvue de toute �l�gance, est l'accessoire parfait pour les zombies qui veulent s�duire mais qui finissent par ressembler � une caricature de mannequin d�filant sur un catwalk de l'horreur.";
                    case "Torse":
                        return "Les zombies qui veulent s�duire mais qui finissent par ressembler � un mannequin de vitrine mal habill�.";
                    case "Bras droit":
                        return "Une sorci�re maladroite, avec des ongles vernis qui semblent avoir surv�cu � une bataille de nail art.";
                    case "Bras gauche":
                        return "Une sorci�re maladroite, avec des ongles vernis qui semblent avoir surv�cu � une bataille de nail art.";
                    case "Jambe droite":
                        return "Une danseuse fatigu�e apr�s une soir�e en talons aiguilles";
                    case "Jambe gauche":
                        return "Une danseuse fatigu�e apr�s une soir�e en talons aiguilles";
                }
                break;
            case "Gangster":
                switch (part)
                {
                    case "T�te":
                        return "Plus d�coiff�e que vos plans pour l'avenir !";
                    case "Torse":
                        return "Avec son t-shirt trou� qui est aussi authentique que vos convictions anarchistes, et des tatouages plus punk que vos slogans de manif : Ce torse est le symbole vivant de la r�bellion !";
                    case "Bras droit":
                        return "Le bras qui secoue l'apocalypse avec un style d�cadent. Tatouages �caill�s et clous rouill�s: c'est �a, la vraie r�bellion.\r\n";
                    case "Bras gauche":
                        return "Le bras qui secoue l'apocalypse avec un style d�cadent. Tatouages �caill�s et clous rouill�s: c'est �a, la vraie r�bellion.\r\n";
                    case "Jambe droite":
                        return "Avec plus de trous que votre compte en banque apr�s une soir�e punk, et des bottes clout�es plus pointues que vos r�pliques dans un d�bat, cette jambe sera l�accessoire parfait pour marcher avec style dans la d�cadence !";
                    case "Jambe gauche":
                        return "Avec plus de trous que votre compte en banque apr�s une soir�e punk, et des bottes clout�es plus pointues que vos r�pliques dans un d�bat, cette jambe sera l�accessoire parfait pour marcher avec style dans la d�cadence !";
                }
                break;
            case "Rastafara":
                switch (part)
                {
                    case "T�te":
                        return "Une coiffure plus sauvage que vos soir�es les plus folles! La stone attitude";
                    case "Torse":
                        return "Plus d�contract� que votre jour de cong�!";
                    case "Bras droit":
                        return "Ce bras vous raconteras au travers de ses tatouages, des histoires qui vous feront voyager � travers le cosmos.";
                    case "Bras gauche":
                        return "Ce bras vous raconteras au travers de ses tatouages, des histoires qui vous feront voyager � travers le cosmos.";
                    case "Jambe droite":
                        return "Marchez au rythme de la d�contraction!";
                    case "Jambe gauche":
                        return "Marchez au rythme de la d�contraction!";
                }
                break;
            case "Popstar":
                switch (part)
                {
                    case "T�te":
                        return "Ce torse zombie, d�pourvu de tout charisme, est l'accessoire parfait pour les zombies qui veulent �tre le roi de la piste mais finissent par �tre le clown de la soir�e.";
                    case "Torse":
                        return "Ce torse zombie, d�pourvu de tout charisme, est l'accessoire parfait pour les zombies qui veulent �tre le roi de la piste mais finissent par �tre le clown de la soir�e.";
                    case "Bras droit":
                        return "Ce bras zombie, d�nu� de tout moonwalk, est le parfait accessoire pour les zombies qui veulent faire revivre les ann�es 80 avec une touche de d�composition.";
                    case "Bras gauche":
                        return "Ce bras zombie, d�nu� de tout moonwalk, est le parfait accessoire pour les zombies qui veulent faire revivre les ann�es 80 avec une touche de d�composition.";
                    case "Jambe droite":
                        return "Cette jambe zombie, d�pourvue de tout rythme, est l'accessoire parfait pour les zombies qui veulent montrer leur c�t� groove mais qui finissent par ressembler � une parade de marionnettes d�sarticul�es.\r\n";
                    case "Jambe gauche":
                        return "Cette jambe zombie, d�pourvue de tout rythme, est l'accessoire parfait pour les zombies qui veulent montrer leur c�t� groove mais qui finissent par ressembler � une parade de marionnettes d�sarticul�es.\r\n";
                }
                break;
        }
        Debug.Log("ERROR");
        return "error";
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

