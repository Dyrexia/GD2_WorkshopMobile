using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_CreateZombie : MonoBehaviour
{
    // Start is called before the first frame update
  
    public void CreateZombie ()
    {
        if (MainManager.Instance.PlayerData.zombieList.Count < MainManager.Instance.PlayerData.MaxZombies)
        {
            MainManager.Instance.PlayerData.zombieList.Add(new ZombieData());

        }
        
        
    }
}
