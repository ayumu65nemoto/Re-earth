using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainvolumeScript : MonoBehaviour
{

    public UnityEngine.Audio.AudioMixer mixer;

    public float GetVolume;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.GetFloat("master", GetVolume);

        GetVolume = PlayerPrefs.GetFloat("master",1);//

        Debug.Log("���j���[������炤Start" + PlayerPrefs.GetFloat("master", GetVolume));//�����̓Z�[�u�����l���o�܂��B
    }

}
