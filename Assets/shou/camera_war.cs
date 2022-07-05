using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_war : MonoBehaviour
{
    // 値を変化させる秒数です。
    float animTime = 3.0f;

    // アニメーションの終了予定時刻です。
    float finishTime;

    // アニメーションの初期位置です。
    Vector3 initPos;

    // アニメーションの終了位置です。
    Vector3 targetPos;

    // 注視したいオブジェクト
    public GameObject targetObject;

    void Start()
    {
        // アニメーションを開始できるように情報をセットします。
        finishTime = Time.time + animTime;
        initPos = gameObject.transform.position;
        targetPos = new Vector3(initPos.x + 30.0f, initPos.y+20.0f, initPos.z-20.0f);
    }

    void Update()
    {

        if (Time.time < finishTime)
        {
        // アニメーションの残り時間を取得します。
            float restTime = finishTime - Time.time;

        // アニメーションの経過時間を取得します。
            float elapsedTime = Mathf.Clamp01((finishTime - restTime) / animTime);

        // 時間に応じた現在の位置を取得してセットします。
            Vector3 pos = Vector3.Lerp(initPos, targetPos, elapsedTime);
            gameObject.transform.position = pos;

        }
        if (Time.time > finishTime)
        {
            //回転を与える
            transform.RotateAround(targetObject.transform.position, new Vector3(0, 1, 0), 0.3f);
        }
    }
}