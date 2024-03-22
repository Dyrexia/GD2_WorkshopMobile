using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Return : MonoBehaviour
{
    public List<ItemData> MissionGains = new List<ItemData>();
    private string[] bodyparts = { "Tête","Torse","Bras droit","Bras gauche","Jambe droite","Jambe gauche" };
    private ZombieData Zombie ;
    private void OnEnable()
    {
        Zombie = MainManager.Instance.PlayerData.zombieList[MainManager.Instance.CurrentZombie];
    }
    public void AcceptEnd()
    {
        Debug.Log("IsReturning est false");
        Zombie.IsReturning = false;
    }
    public void GenerateItems(DateTime MissionDuration)
    {
        int items = MissionDuration.Hour + 1;
        for (int i = 0; i < items; i++)
        {
            int levelModifier = (Zombie.GetIntelligence() / 6) + UnityEngine.Random.Range(-1, 1)+(int)MathF.Round(Zombie.MissionDifficulty)/2;
            MissionGains.Add(new ItemData(bodyparts[UnityEngine.Random.Range(0,bodyparts.Length)],Mathf.Min(levelModifier,15)));
        }
        foreach (ItemData item in MissionGains)
        {
            ItemWrapper itemWrapper = new ItemWrapper();
            itemWrapper.ItemData = item;
            MainManager.Instance.PlayerData.ItemLists[item.Bodypart].Items.Add(itemWrapper);
        }
        MissionGains.Clear();
    }
    public int MissionEndStats(int t)
    {
        return Mathf.FloorToInt(((2/3)*Zombie.GetInfection()*Zombie.GetPower()*t*Mathf.Sqrt(t)-(Mathf.Pow(t-Zombie.GetStealth(),Zombie.MissionDifficulty+1)/(Zombie.MissionDifficulty+3))) / Zombie.GetPower());
    }
}
