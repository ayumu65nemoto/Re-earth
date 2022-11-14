using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingBGM : MonoBehaviour
{
    [SerializeField]
    SoundManager soundManager;
    [SerializeField]
    AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        soundManager = GameObject.FindWithTag("SoundManager")?.GetComponent<SoundManager>();
        soundManager.PlayBgm(clip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
