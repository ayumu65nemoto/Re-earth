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
        //ボスを非アクティブにしておく
        boss.SetActive(false);
        appearScript = GetComponent<AppearScript>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //雑魚敵を一定数倒すとボスをアクティブにする
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
        //エフェクトを生成する
        GameObject appear_effect = Instantiate(appearEffect) as GameObject;
        //エフェクトが発生する場所を決定する(敵オブジェクトの場所)
        appear_effect.transform.position = gameObject.transform.position;
        //エフェクトを消す
        Destroy(appear_effect, 1.0f);
    }
}
