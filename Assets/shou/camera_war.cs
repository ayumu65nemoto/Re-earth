using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_war : MonoBehaviour
{
    // �l��ω�������b���ł��B
    float animTime = 3.0f;

    // �A�j���[�V�����̏I���\�莞���ł��B
    float finishTime;

    // �A�j���[�V�����̏����ʒu�ł��B
    Vector3 initPos;

    // �A�j���[�V�����̏I���ʒu�ł��B
    Vector3 targetPos;

    // �����������I�u�W�F�N�g
    public GameObject targetObject;

    void Start()
    {
        // �A�j���[�V�������J�n�ł���悤�ɏ����Z�b�g���܂��B
        finishTime = Time.time + animTime;
        initPos = gameObject.transform.position;
        targetPos = new Vector3(initPos.x + 30.0f, initPos.y+20.0f, initPos.z-20.0f);
    }

    void Update()
    {

        if (Time.time < finishTime)
        {
        // �A�j���[�V�����̎c�莞�Ԃ��擾���܂��B
            float restTime = finishTime - Time.time;

        // �A�j���[�V�����̌o�ߎ��Ԃ��擾���܂��B
            float elapsedTime = Mathf.Clamp01((finishTime - restTime) / animTime);

        // ���Ԃɉ��������݂̈ʒu���擾���ăZ�b�g���܂��B
            Vector3 pos = Vector3.Lerp(initPos, targetPos, elapsedTime);
            gameObject.transform.position = pos;

        }
        if (Time.time > finishTime)
        {
            //��]��^����
            transform.RotateAround(targetObject.transform.position, new Vector3(0, 1, 0), 0.3f);
        }
    }
}