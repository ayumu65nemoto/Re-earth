using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossStatus : MonoBehaviour
{
    //敵のMaxHP
    [SerializeField]
    private int maxHp = 15;
    //　敵のHP
    [SerializeField]
    private int hp = 3;
    // HP表示用UI
    [SerializeField]
    private GameObject HPUI;
    //HP表示用スライダー
    private Slider hpSlider;

    void Start()
    {
        hp = maxHp;
        hpSlider = HPUI.transform.Find("HPBar").GetComponent<Slider>();
        hpSlider.value = 1f;
    }

    public void SetHp(int hp)
    {
        this.hp = hp;

        //HP表示用UIのアップデート
        UpdateHPValue();

        if (hp <= 0)
        {
            //HP表示用UIを非表示にする
            HideStatusUI();
        }
    }

    public int GetHp()
    {
        return hp;
    }

    public int GetMaxHp()
    {
        return maxHp;
    }

    //死んだらHPUIを非表示にする
    public void HideStatusUI()
    {
        HPUI.SetActive(false);
    }

    public void UpdateHPValue()
    {
        hpSlider.value = (float)GetHp() / (float)GetMaxHp();
    }
}
