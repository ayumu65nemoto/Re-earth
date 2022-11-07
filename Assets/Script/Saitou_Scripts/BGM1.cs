using UnityEngine;
public class BGM1 : MonoBehaviour
{
    [SerializeField]
    SoundManager soundManager;
    [SerializeField]
    AudioClip clip;
    void Start()
    {
        soundManager.PlayBgm(clip);
    }
}