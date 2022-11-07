using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSettingScript : MonoBehaviour
{
    public UnityEngine.Audio.AudioMixer mixer;  //�~�L�T�[�쐬�錾

    public Slider VolumeSlider;  //�X���C�_�[�쐬�錾

    public static float GetVolume;  //���ʕϐ��쐬�錾

    void Awake()
    {
        GetComponent<Slider>().value = PlayerPrefs.GetFloat("master", 0);

        float GetVolume = VolumeSlider.value;

        PlayerPrefs.SetFloat("GetVolume", VolumeSlider.value);

        Debug.Log("�X�e�[�W�ɓn��" + PlayerPrefs.GetFloat("GetVolume", GetVolume));
        Debug.Log("�X���C�_�[�l" + VolumeSlider.value);

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
        Slider VolumeSlider = gameObject.GetComponent<Slider>();  //�X���C�_�[�̕ω�����Ɏ擾����
    }
}
