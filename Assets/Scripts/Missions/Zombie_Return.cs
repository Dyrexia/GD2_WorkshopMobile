using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Return : MonoBehaviour
{
List<ItemData> MissionGains = new List<ItemData>();
    private ZombieData Zombie = MainManager.Instance.PlayerData.zombieList[MainManager.Instance.CurrentZombie];
    public void GenerateItems()
    {
    }
}
