using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_InventoryButton_ChangeImage : MonoBehaviour
{
    public void UpdateImage(Sprite sprite)
    {
        GetComponent<Image>().sprite = sprite;
    }
}
