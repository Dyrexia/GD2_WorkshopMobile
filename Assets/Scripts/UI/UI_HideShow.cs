using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_HideShow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void HideCanvas()
    {
        gameObject.SetActive(false);
    }
    public void ShowCanvas()
    {
        gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
