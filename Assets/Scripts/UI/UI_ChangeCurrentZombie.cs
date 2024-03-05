using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ChangeCurrentZombie : MonoBehaviour
{
    UI_ZombieStat ZombiesStats;
    public void Awake()
    {
        ZombiesStats = GameObject.FindGameObjectWithTag("ZombieStats").GetComponent<UI_ZombieStat>();
    }
    // Start is called before the first frame update
    public void CycleZombieBack()//si on est au d�but on repasse au fond sinon on va vers l'arri�re
    {
        if (MainManager.Instance.CurrentZombie == 0)
            MainManager.Instance.CurrentZombie = MainManager.Instance.PlayerData.zombieList.Count - 1;
        else
            MainManager.Instance.CurrentZombie--;
        ZombiesStats.showZombieStat();
    }
    public void CycleZombieForward()//inverse
    {
        if(MainManager.Instance.CurrentZombie == MainManager.Instance.PlayerData.zombieList.Count - 1)
            MainManager.Instance.CurrentZombie = 0;
        else
            MainManager.Instance.CurrentZombie++;
        ZombiesStats.showZombieStat();
    }
}
