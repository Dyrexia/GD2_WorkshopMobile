using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Return : MonoBehaviour
{
    public List<ItemData> MissionGains = new List<ItemData>();
    private string[] bodyparts = { "Tête","Torse","Bras droit","Bras gauche","Jambe droite","Jambe gauche" };
    private ZombieData Zombie = MainManager.Instance.PlayerData.zombieList[MainManager.Instance.CurrentZombie];
    public void GenerateItems(DateTime MissionDuration)
    {
        int items = MissionDuration.Hour + 1;
        for (int i = 0; i < items; i++)
        {
            int levelModifier = (Zombie.GetIntelligence() / 6) + UnityEngine.Random.Range(-1, 2)+(int)MathF.Round(Zombie.MissionDifficulty);
            MissionGains.Add(new ItemData(bodyparts[UnityEngine.Random.Range(0,bodyparts.Length)],levelModifier));
        }
    }
    public int MissionEndStats(int t)
    {
        return Mathf.FloorToInt(((2/3)*Zombie.GetInfection()*Zombie.GetPower()*t*Mathf.Sqrt(t)-(Mathf.Pow(t-Zombie.GetStealth(),Zombie.MissionDifficulty+1)/(Zombie.MissionDifficulty+3))) / Zombie.GetPower());
    }
}
