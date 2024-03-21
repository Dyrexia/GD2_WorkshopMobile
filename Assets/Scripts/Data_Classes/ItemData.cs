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
    public ItemData(string bodypart, int level = 0)//constructeur de la classe : seule la bodypart et le level sont importants, le reste est généré aléatoirement à partir de ces 2 infos
    {
        Bodypart = bodypart;
        Level = level;
        SkinLabel = GetSkin(level);
        Description = DescriptionHolder.GetDescription(Bodypart, SkinLabel);
        IsInBarrel = false;
        Name = Bodypart + NameChar[level/5];
        GenerateRandomModifier();
        Infection = Mathf.CeilToInt((0.13f * level / 2) * (1 + (RandomGeneration.z + Bias.z)));//version factorisé
        Intelligence = level;
        Power = Mathf.FloorToInt((Mathf.Pow(2.23f, level) / 2) * (1 + (RandomGeneration.x + Bias.x)));//version factorisé
        Stealth = Mathf.FloorToInt(15 * Mathf.Pow(level, (1/5)) * (1+(RandomGeneration.y + Bias.y)));//version factorisé
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
public static class DescriptionHolder
{
    public static string GetDescription(string part,string skin)
    {
        switch (skin) 
        {
            case "Basique":
                switch (part)
                {
                    case "Tête":
                        return "Cette tête zombie, dénuée de toute intelligence, est le joyau de la couronne des horreurs, le parfait accessoire pour les zombies qui veulent se démarquer dans le monde grotesque des non-morts.";
                    case "Torse":
                        return "Ce torse zombie, dépourvu de tout six-pack, est la quintessence de la mode débraillée, le vêtement idéal pour ceux qui veulent faire sensation dans le monde des morts-vivants.";
                    case "Bras droit":
                        return "Avec ses ongles écaillés et sa peau décolorée, il semble avoir été emprunté à une vieille marionnette oubliée dans un placard poussiéreux. Ce bras zombie, dépourvu de toute grâce, est le parfait accessoire pour les zombies qui cherchent à impressionner avec leur style débraillé et leur désir insatiable de chair fraîche.\r\n";
                    case "Bras gauche":
                        return "Avec ses ongles écaillés et sa peau décolorée, il semble avoir été emprunté à une vieille marionnette oubliée dans un placard poussiéreux. Ce bras zombie, dépourvu de toute grâce, est le parfait accessoire pour les zombies qui cherchent à impressionner avec leur style débraillé et leur désir insatiable de chair fraîche.\r\n";
                    case "Jambe droite":
                        return "Cette jambe zombie, aux articulations désarticulées, est le parfait accessoire pour les zombies qui veulent donner l'impression d'avoir toujours un pied dans la tombe, littéralement.";
                    case "Jambe gauche":
                        return "Cette jambe zombie, aux articulations désarticulées, est le parfait accessoire pour les zombies qui veulent donner l'impression d'avoir toujours un pied dans la tombe, littéralement.";
                }
                break;
            case "Feminin":
                switch (part)
                {
                    case "Tête":
                        return "Dépourvue de toute élégance, est l'accessoire parfait pour les zombies qui veulent séduire mais qui finissent par ressembler à une caricature de mannequin défilant sur un catwalk de l'horreur.";
                    case "Torse":
                        return "Les zombies qui veulent séduire mais qui finissent par ressembler à un mannequin de vitrine mal habillé.";
                    case "Bras droit":
                        return "Une sorcière maladroite, avec des ongles vernis qui semblent avoir survécu à une bataille de nail art.";
                    case "Bras gauche":
                        return "Une sorcière maladroite, avec des ongles vernis qui semblent avoir survécu à une bataille de nail art.";
                    case "Jambe droite":
                        return "Une danseuse fatiguée après une soirée en talons aiguilles";
                    case "Jambe gauche":
                        return "Une danseuse fatiguée après une soirée en talons aiguilles";
                }
                break;
            case "Gangster":
                switch (part)
                {
                    case "Tête":
                        return "Plus décoiffée que vos plans pour l'avenir !";
                    case "Torse":
                        return "Avec son t-shirt troué qui est aussi authentique que vos convictions anarchistes, et des tatouages plus punk que vos slogans de manif : Ce torse est le symbole vivant de la rébellion !";
                    case "Bras droit":
                        return "Le bras qui secoue l'apocalypse avec un style décadent. Tatouages écaillés et clous rouillés: c'est ça, la vraie rébellion.\r\n";
                    case "Bras gauche":
                        return "Le bras qui secoue l'apocalypse avec un style décadent. Tatouages écaillés et clous rouillés: c'est ça, la vraie rébellion.\r\n";
                    case "Jambe droite":
                        return "Avec plus de trous que votre compte en banque après une soirée punk, et des bottes cloutées plus pointues que vos répliques dans un débat, cette jambe sera l’accessoire parfait pour marcher avec style dans la décadence !";
                    case "Jambe gauche":
                        return "Avec plus de trous que votre compte en banque après une soirée punk, et des bottes cloutées plus pointues que vos répliques dans un débat, cette jambe sera l’accessoire parfait pour marcher avec style dans la décadence !";
                }
                break;
            case "Rastafara":
                switch (part)
                {
                    case "Tête":
                        return "Une coiffure plus sauvage que vos soirées les plus folles! La stone attitude";
                    case "Torse":
                        return "Plus décontracté que votre jour de congé!";
                    case "Bras droit":
                        return "Ce bras vous raconteras au travers de ses tatouages, des histoires qui vous feront voyager à travers le cosmos.";
                    case "Bras gauche":
                        return "Ce bras vous raconteras au travers de ses tatouages, des histoires qui vous feront voyager à travers le cosmos.";
                    case "Jambe droite":
                        return "Marchez au rythme de la décontraction!";
                    case "Jambe gauche":
                        return "Marchez au rythme de la décontraction!";
                }
                break;
            case "Popstar":
                switch (part)
                {
                    case "Tête":
                        return "Ce torse zombie, dépourvu de tout charisme, est l'accessoire parfait pour les zombies qui veulent être le roi de la piste mais finissent par être le clown de la soirée.";
                    case "Torse":
                        return "Ce torse zombie, dépourvu de tout charisme, est l'accessoire parfait pour les zombies qui veulent être le roi de la piste mais finissent par être le clown de la soirée.";
                    case "Bras droit":
                        return "Ce bras zombie, dénué de tout moonwalk, est le parfait accessoire pour les zombies qui veulent faire revivre les années 80 avec une touche de décomposition.";
                    case "Bras gauche":
                        return "Ce bras zombie, dénué de tout moonwalk, est le parfait accessoire pour les zombies qui veulent faire revivre les années 80 avec une touche de décomposition.";
                    case "Jambe droite":
                        return "Cette jambe zombie, dépourvue de tout rythme, est l'accessoire parfait pour les zombies qui veulent montrer leur côté groove mais qui finissent par ressembler à une parade de marionnettes désarticulées.\r\n";
                    case "Jambe gauche":
                        return "Cette jambe zombie, dépourvue de tout rythme, est l'accessoire parfait pour les zombies qui veulent montrer leur côté groove mais qui finissent par ressembler à une parade de marionnettes désarticulées.\r\n";
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

