using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossStatus : MonoBehaviour
{
    //�G��MaxHP
    [SerializeField]
    private int maxHp = 15;
    //�@�G��HP
    [SerializeField]
    private int hp = 3;
    // HP�\���pUI
    [SerializeField]
    private GameObject HPUI;
    //HP�\���p�X���C�_�[
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

        //HP�\���pUI�̃A�b�v�f�[�g
        UpdateHPValue();

        if (hp <= 0)
        {
            //HP�\���pUI���\���ɂ���
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

    //���񂾂�HPUI���\���ɂ���
    public void HideStatusUI()
    {
        HPUI.SetActive(false);
    }

    public void UpdateHPValue()
    {
        hpSlider.value = (float)GetHp() / (float)GetMaxHp();
    }
}
