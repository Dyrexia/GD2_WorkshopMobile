using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class Zombie_Visuals : MonoBehaviour
{
    public UI_HideShow StatsCanvas;
    private void UpdateZombieSkin()
    {
        foreach (SpriteResolver resolver in GetComponentsInChildren<SpriteResolver>())
        {
            resolver.SetCategoryAndLabel(resolver.GetCategory(), MainManager.Instance.PlayerData.zombieList[MainManager.Instance.CurrentZombie].EquippedParts[resolver.GetCategory()].SkinLabel);
        }
        
    }
    private void Start()
    {
        UpdateScreen();
    }
    private void OnEnable()
    {
        if (MainManager.Instance.PlayerData.zombieList.Count != 0)
        UpdateScreen();
    }
    public void UpdateScreen()
    {
        if (MainManager.Instance.PlayerData.zombieList[MainManager.Instance.CurrentZombie].IsAway==true)
        {
            StatsCanvas.ShowCanvas();
        }
        else
        {
            StatsCanvas.HideCanvas();
        }
        UpdateZombieSkin();
    }
}
