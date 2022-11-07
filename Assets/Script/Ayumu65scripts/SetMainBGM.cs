using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMainBGM : MonoBehaviour
{
    public UnityEngine.Audio.AudioMixer mixer;

    public static float GetVolume;

    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.GetFloat("master", GetVolume);
        GetVolume = PlayerPrefs.GetFloat("master", 1);

        mixer.SetFloat("master", GetVolume);//Ç±Ç±Ç™ã@î\ÇµÇ‹ÇπÇÒÅB
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
