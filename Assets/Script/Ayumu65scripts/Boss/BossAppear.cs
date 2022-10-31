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
    public GameObject appearEffect;
    private float lapsedTime;

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
        if (deadCounts == 3)
        {
            lapsedTime += Time.deltaTime;
            GenerateApperEffect();
            if (lapsedTime > 2)
            {
                boss.SetActive(true);
                audioSource.PlayOneShot(appearSE);
            }
        }
    }

    void GenerateApperEffect()
    {
        //�G�t�F�N�g�𐶐�����
        GameObject appear_effect = Instantiate(appearEffect) as GameObject;
        //�G�t�F�N�g����������ꏊ�����肷��(�G�I�u�W�F�N�g�̏ꏊ)
        appear_effect.transform.position = gameObject.transform.position;
        //�G�t�F�N�g������
        Destroy(appear_effect, 1.0f);
    }
}
