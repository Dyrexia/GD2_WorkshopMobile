using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ProgressBarStat : MonoBehaviour
{
    private Slider SliderRef;
    

    private void Start() 
    {
        SliderRef= GetComponent<Slider>();
    }
    public void UpdateNumber(float NewValue, Color color)
    {
        SliderRef.value = NewValue;
        gameObject.GetComponentInChildren<Image>().color = color;


        
    }
    


}
