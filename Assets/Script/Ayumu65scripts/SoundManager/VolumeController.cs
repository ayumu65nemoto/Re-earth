using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public enum VolumeType { BGM, SE }

    [SerializeField]
    VolumeType volumeType = 0;

    Slider slider;
    SoundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        soundManager = GameObject.FindWithTag("SoundManager")?.GetComponent<SoundManager>(); //SoundManagerÇéQè∆

        switch (volumeType)
        {
            case VolumeType.BGM:
                slider.value = soundManager.BgmVolume;
                break;
            case VolumeType.SE:
                slider.value = soundManager.SeVolume;
                break;
        }
    }

   public void OnValueChanged()
   {
        switch (volumeType)
        {
            case VolumeType.BGM:
                soundManager.BgmVolume = slider.value;
                break;
            case VolumeType.SE:
                soundManager.SeVolume = slider.value;
                break;
        }
   }
}
