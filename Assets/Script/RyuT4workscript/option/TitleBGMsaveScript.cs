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
        Debug.Log("�X�e�[�W�ɓn��" + PlayerPrefs.GetFloat("master", 0));
        Debug.Log("master�Z�[�u�l" + PlayerPrefs.GetFloat("master", 0));
        Debug.Log("GetVolume�Z�[�u�l" + PlayerPrefs.GetFloat("GetVolume", 0));
    }

}
