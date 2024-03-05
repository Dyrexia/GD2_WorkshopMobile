using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public List<AudioClip> audioclips;
    public AudioSource audiosource;

    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playsound1() {
    audiosource.clip = audioclips[0];
        audiosource.Play();
    }
    public void playsound2()
    {
        audiosource.clip = audioclips[1];
        audiosource.Play();
    }

}
