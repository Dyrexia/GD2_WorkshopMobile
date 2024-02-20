using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Away : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private float NumberOfZombies(float t,float MilStr,int infection=0, int power = 0)
    {
        return Mathf.Floor(Mathf.Sqrt(t) * infection - MilStr / power);
    }
    private float MilitaryStrength(float t,bool HaveArrived,float TimeOfArrival=0) 
    {
        if (HaveArrived)
        {
            return (t - TimeOfArrival) * (t - TimeOfArrival);
        }
        return 0f;
    }
    private void ShowZombieProgression()
    {
        StartCoroutine(UpdateZombieProgression(1));
    }
    private void HideZombieProgression()
    {
        StopCoroutine("UpdateZombieProgression");
    }
    public IEnumerator UpdateZombieProgression(int zombieID)
    {
        int t=0;
        int MissionDuration=0;
        int TimeOfArrival= 0;
        bool HaveArrived=false;
        while (t < MissionDuration)
        {
            t += 1;
            if (t > TimeOfArrival)
            {
                HaveArrived = true;
            }
            Debug.Log("NZombies : " + NumberOfZombies(t, MilitaryStrength(t, HaveArrived)).ToString() + " Time : " + t.ToString());
        }
        yield return new WaitForSeconds(1);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
