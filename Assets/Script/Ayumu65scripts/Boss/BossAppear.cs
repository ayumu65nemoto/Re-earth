using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAppear : MonoBehaviour
{
    public GameObject boss;
    public AppearScript appearScript;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip appearSE;
    // Start is called before the first frame update
    void Start()
    {
        //�{�X���A�N�e�B�u�ɂ��Ă���
        boss.SetActive(false);
        appearScript = GetComponent<AppearScript>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //�G���G����萔�|���ƃ{�X���A�N�e�B�u�ɂ���
        var deadCounts = appearScript.deadCount + appearScript.deadCount2;
        if (deadCounts == 10)
        {
            boss.SetActive(true);
            audioSource.PlayOneShot(appearSE);
        }
    }
}
