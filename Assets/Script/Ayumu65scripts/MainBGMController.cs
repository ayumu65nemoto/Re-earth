using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainBGMController : MonoBehaviour
{
    public UnityEngine.Audio.AudioMixer mixer;
    public Slider VolumeSlider;
    public float GetVolume;
    
    void Awake()
    {
        GetComponent<Slider>().value = PlayerPrefs.GetFloat("master", 0);
        float GetVolume = VolumeSlider.value;
        PlayerPrefs.SetFloat("GetVolume", VolumeSlider.value);
    }

    public void masterVol(Slider VolumeSlider)
    {
        if (PlayerPrefs.HasKey("master"))
        {
            PlayerPrefs.GetFloat("master", VolumeSlider.value);
            mixer.SetFloat("master", VolumeSlider.value);
        }
        else
        {
            mixer.SetFloat("master", -20);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Slider VolumeSlider = gameObject.GetComponent<Slider>();
    }
}
