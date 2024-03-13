using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ChangeCurrentZombie : MonoBehaviour
{
    UI_ZombieStat ZombiesStats;
    // Start is called before the first frame update
    public void CycleZombieBack()//si on est au début on repasse au fond sinon on va vers l'arrière
    {
        if (MainManager.Instance.CurrentZombie == 0)
            MainManager.Instance.CurrentZombie = MainManager.Instance.PlayerData.zombieList.Count - 1;
        else
            MainManager.Instance.CurrentZombie--;
        UpdateZombie();
    }
    public void CycleZombieForward()//inverse
    {
        if(MainManager.Instance.CurrentZombie == MainManager.Instance.PlayerData.zombieList.Count - 1)
            MainManager.Instance.CurrentZombie = 0;
        else
            MainManager.Instance.CurrentZombie++;
        UpdateZombie();
    }
    private void UpdateZombie()
    {
        GameObject.FindGameObjectWithTag("Zombie").GetComponent<Zombie_Visuals>().UpdateZombieSkin();
    }
}
