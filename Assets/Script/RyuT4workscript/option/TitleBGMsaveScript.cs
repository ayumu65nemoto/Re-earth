using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleBGMsaveScript : MonoBehaviour
{

    public Slider VolumeSlider;

    public void OnClick()
    {
        SceneManager.LoadScene("title");



        PlayerPrefs.SetFloat("master", VolumeSlider.value);
        PlayerPrefs.SetFloat("GetVolume", VolumeSlider.value);
        PlayerPrefs.Save();
        Debug.Log("ステージに渡す" + PlayerPrefs.GetFloat("master", 0));
        Debug.Log("masterセーブ値" + PlayerPrefs.GetFloat("master", 0));
        Debug.Log("GetVolumeセーブ値" + PlayerPrefs.GetFloat("GetVolume", 0));
    }

}
