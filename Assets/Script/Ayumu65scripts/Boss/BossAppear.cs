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
    private bool appearFlag;
    public GameObject arrow;

    // Start is called before the first frame update
    void Start()
    {
        //�{�X���A�N�e�B�u�ɂ��Ă���
        boss.SetActive(false);
        //�����A�N�e�B�u�ɂ��Ă���
        arrow.SetActive(false);
        appearScript = GetComponent<AppearScript>();
        audioSource = GetComponent<AudioSource>();
        appearFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        //�G���G����萔�|���ƃ{�X���A�N�e�B�u�ɂ���
        var deadCounts = appearScript.deadCount + appearScript.deadCount2;
        if (deadCounts == 3)
        {
            if (!appearFlag)
            {
                lapsedTime += Time.deltaTime;
                GenerateApperEffect();
                arrow.SetActive(true);
                if (lapsedTime > 1)
                {
                    boss.SetActive(true);
                    audioSource.PlayOneShot(appearSE);
                    appearFlag = true;
                }

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
        Destroy(appear_effect, 3.0f);
    }
}
