using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;
using UnityEngine.UI;


public class UI_ZombiePart : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        GetComponent<Image>().sprite= gameObject.GetComponentInParent<SpriteLibrary>().GetSprite(GetComponent<SpriteResolver>().GetCategory(), MainManager.Instance.PlayerData.zombieList[MainManager.Instance.CurrentZombie].EquippedParts[GetComponent<SpriteResolver>().GetCategory()].SkinLabel);
    }
}
