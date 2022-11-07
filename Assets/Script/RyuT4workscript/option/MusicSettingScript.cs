using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSettingScript : MonoBehaviour
{
    public UnityEngine.Audio.AudioMixer mixer;  //ミキサー作成宣言

    public Slider VolumeSlider;  //スライダー作成宣言

    public static float GetVolume;  //音量変数作成宣言

    void Awake()
    {
        GetComponent<Slider>().value = PlayerPrefs.GetFloat("master", 0);

        float GetVolume = VolumeSlider.value;

        PlayerPrefs.SetFloat("GetVolume", VolumeSlider.value);

        Debug.Log("ステージに渡す" + PlayerPrefs.GetFloat("GetVolume", GetVolume));
        Debug.Log("スライダー値" + VolumeSlider.value);

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
        Slider VolumeSlider = gameObject.GetComponent<Slider>();  //スライダーの変化を常に取得する
    }
}
