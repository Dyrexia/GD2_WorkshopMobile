using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Away : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        while (t < MissionDuration)
        {
            t += 1;
            if (t > TimeOfArrival)
            {
                HaveArrived=true;
            }
            Debug.Log("NZombies : " + NumberOfZombies(t, MilitaryStrength(t, HaveArrived)).ToString() + " Time : " + t.ToString());
        }
    }
    private float infection=10f;
    private float power=50f;
    private float t=0f;
    private float TimeOfArrival=200f;
    private float MissionDuration = 1000f;
    private bool HaveArrived = false;

    private float NumberOfZombies(float t,float MilStr)
    {
        return Mathf.Floor(Mathf.Sqrt(t) * infection - MilStr / power);
    }
    private float MilitaryStrength(float t,bool HaveArrived) 
    {
        if (HaveArrived)
        {
            return (t - TimeOfArrival) * (t - TimeOfArrival);
        }
        return 0f;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
