using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMChangeScript : MonoBehaviour
{

    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void SoundSliderOnValueChange(float newSliderValue)
    {
        // 音楽の音量をスライドバーの値に変更
        audioSource.volume = newSliderValue;
    }
}
