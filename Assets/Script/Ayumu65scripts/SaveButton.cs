using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveButton : MonoBehaviour
{
    public Slider VolumeSlider;
    
    public void OnClick()
    {
        SceneManager.LoadScene("Title");

        PlayerPrefs.SetFloat("master", VolumeSlider.value);
        PlayerPrefs.SetFloat("GetVolume", VolumeSlider.value);
        PlayerPrefs.Save();
    }
}
