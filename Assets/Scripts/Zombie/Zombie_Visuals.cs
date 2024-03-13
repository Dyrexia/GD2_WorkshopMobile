using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class Zombie_Visuals : MonoBehaviour
{
    public void UpdateZombieSkin()
    {
        foreach (SpriteResolver resolver in GetComponentsInChildren<SpriteResolver>())
        {
            resolver.SetCategoryAndLabel(resolver.GetCategory(), MainManager.Instance.PlayerData.zombieList[MainManager.Instance.CurrentZombie].EquippedParts[resolver.GetCategory()].SkinLabel);
        }
    }
    private void Start()
    {
        UpdateZombieSkin();
    }
}
