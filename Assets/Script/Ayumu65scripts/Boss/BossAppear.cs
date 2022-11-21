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
        //ボスを非アクティブにしておく
        boss.SetActive(false);
        //矢印を非アクティブにしておく
        arrow.SetActive(false);
        appearScript = GetComponent<AppearScript>();
        audioSource = GetComponent<AudioSource>();
        appearFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        //雑魚敵を一定数倒すとボスをアクティブにする
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
        //エフェクトを生成する
        GameObject appear_effect = Instantiate(appearEffect) as GameObject;
        //エフェクトが発生する場所を決定する(敵オブジェクトの場所)
        appear_effect.transform.position = gameObject.transform.position;
        //エフェクトを消す
        Destroy(appear_effect, 3.0f);
    }
}
